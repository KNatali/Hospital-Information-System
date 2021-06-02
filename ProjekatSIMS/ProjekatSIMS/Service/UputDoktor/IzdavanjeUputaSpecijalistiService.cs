using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Service
{
    public class IzdavanjeUputaSpecijalistiService
    {
        private const int TRAJANJE_PREGLEDA = 20;
        private UputRepository uputRepository = new UputRepository();
        private PregledRepository pregledRepository = new PregledRepository();
        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        public Boolean IzdavanjeUputa(Pacijent pacijent, Doktor doktor, DateTime izabraniTermin)
        {
            Prostorija slobodnaOrdinacija = NadjiSlobodnuOrdinaciju(izabraniTermin);
            if (slobodnaOrdinacija == null)
                return false;

            Pregled p = KreiranjePregleda(pacijent, doktor, izabraniTermin, slobodnaOrdinacija);
            pregledRepository.SacuvajPregledDoktor(p);

            DateTime vrijemeIzadavanja = DateTime.Now;
            Uput uput = new Uput(p, vrijemeIzadavanja);
            uputRepository.SacuvajUput(uput);

            return true;
        }

        public Prostorija NadjiSlobodnuOrdinaciju(DateTime terminPocetak)
        {

            IntervalDatuma termin = new IntervalDatuma(terminPocetak, terminPocetak.AddMinutes(TRAJANJE_PREGLEDA));
            List<Pregled> zakazaniPregledi = pregledRepository.DobaviZakazanePreglede();
            List<Prostorija> ordinacije = prostorijaRepository.DobaviPoVrsti(VrstaProstorije.Ordinacija);
            List<Prostorija> slobodneOrdinacije = DobaviSlobodneOrdinacije(termin, zakazaniPregledi, ordinacije);

            if (slobodneOrdinacije.Count == 0)
            {
                MessageBox.Show("Nema slbodnih ordinacija u izabranom terminu. Molimo Vas izaberite neki od drugih ponudjenih termina");
                return null;
            }

            return slobodneOrdinacije[0];
        }

        public List<Prostorija> DobaviSlobodneOrdinacije(IntervalDatuma termin, List<Pregled> zakazaniPregledi, List<Prostorija> ordinacije)
        {
            List<Prostorija> slobodneOrdinacije = ordinacije;

            foreach (Pregled p in zakazaniPregledi)
            {
                if (DaLiSeTerminPoklapa(p, termin))
                    AzuriranjeSlobodnihOrdinacija(ordinacije, slobodneOrdinacije, p);

            }

            return slobodneOrdinacije;
        }

        private static void AzuriranjeSlobodnihOrdinacija(List<Prostorija> ordinacije, List<Prostorija> slobodneOrdinacije, Pregled p)
        {
            for (int i = 0; i < ordinacije.Count; i++)
            {
                if (ordinacije[i].id == p.prostorija.id)
                    slobodneOrdinacije.Remove(ordinacije[i]);
            }
        }

        public Boolean DaLiSeTerminPoklapa(Pregled p, IntervalDatuma termin)
        {
            if (DateTime.Compare(termin.PocetnoVrijeme, p.Pocetak) >= 0 && DateTime.Compare(termin.PocetnoVrijeme, p.Pocetak.AddMinutes(p.Trajanje)) < 0 ||
                   DateTime.Compare(termin.KrajnjeVrijeme, p.Pocetak) > 0 && DateTime.Compare(termin.KrajnjeVrijeme, p.Pocetak.AddMinutes(p.Trajanje)) <= 0)
                return true;
            return false;


        }

        public Pregled KreiranjePregleda(Pacijent pacijent, Doktor doktor, DateTime izabraniTermin, Prostorija slobodnaOrdinacija)
        {
            Pregled pregled = new Pregled();
            pregled.pacijent = pacijent;
            pregled.doktor = doktor;
            pregled.Pocetak = izabraniTermin;
            pregled.Trajanje = TRAJANJE_PREGLEDA;
            pregled.prostorija = slobodnaOrdinacija;
            pregled.StatusPregleda = StatusPregleda.Zakazan;
            pregled.Tip = TipPregleda.Standardni;
            return pregled;
        }
    }
}

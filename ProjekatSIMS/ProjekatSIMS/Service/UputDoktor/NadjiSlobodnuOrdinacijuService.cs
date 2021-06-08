using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Model;
using Repository;

namespace ProjekatSIMS.Service.UputDoktor
{
    public  class NadjiSlobodnuOrdinacijuService
    {
        private const int TRAJANJE_PREGLEDA = 20;
        private UputRepository uputRepository = new UputRepository();
        private PregledRepository pregledRepository = new PregledRepository();
        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        public Prostorija NadjiSlobodnuOrdinaciju(DateTime terminPocetak)
        {

            IntervalDatuma termin = new IntervalDatuma(terminPocetak, terminPocetak.AddMinutes(TRAJANJE_PREGLEDA));
            List<Pregled> zakazaniPregledi = pregledRepository.DobaviZakazanePreglede();
            List<Prostorija> ordinacije = prostorijaRepository.DobaviPoVrsti(VrstaProstorije.Ordinacija);
            List<Prostorija> slobodneOrdinacije = DobaviSlobodneOrdinacije(termin, zakazaniPregledi, ordinacije);

            if (slobodneOrdinacije.Count == 0)
            {
                MessageBox.Show("Nema slobodnih ordinacija u izabranom terminu. Molimo Vas izaberite neki od drugih ponudjenih termina");
                return null;
            }

            return slobodneOrdinacije[0];
        }

        public List<Prostorija> DobaviSlobodneOrdinacije(IntervalDatuma termin, List<Pregled> zakazaniPregledi, List<Prostorija> ordinacije)
        {
            List<Prostorija> slobodneOrdinacije = ordinacije;

            foreach (Pregled p in zakazaniPregledi)
            {
                IntervalDatuma termin2 = new IntervalDatuma(p.Pocetak, p.Pocetak.AddMinutes(p.Trajanje));
                if (termin.DaLiSeTerminiPoklapaju(termin2))
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
    }
}

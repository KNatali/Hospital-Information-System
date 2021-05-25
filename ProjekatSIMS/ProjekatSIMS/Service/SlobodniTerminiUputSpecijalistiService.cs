using Model;
using ProjekatSIMS.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Service
{
    public class SlobodniTerminiUputSpecijalistiService

    {
        private const int TRAJANJE_PREGLEDA = 20;
        public const int POCETAK_RADNOG_VREMENA = 8;
        public const int KRAJ_RADNOG_VREMENA = 20;
        public int MAKSIMALNO_OTKAZIVANJA = 10;
        public Repository.PregledRepository pregledRepository = new PregledRepository();
        
        public UputRepository uputRepository = new UputRepository();
        public List<DateTime> PrikazSlobodnihTermina(SlobodniTerminiUputSpecijalistiDTO podaci)
        {
            List<DateTime> slobodniTermini = DobaviSlobodneTermineDoktora(podaci);
            if (slobodniTermini.Count != 0)
                return slobodniTermini;
            else
            {
                MessageBox.Show("Nema slobodnih termina u datom intervalu.Prikazace se najblizi slobodni termini");
                return PronadjiNoveTermine(podaci);
            }
        }

        public List<DateTime> DobaviSlobodneTermineDoktora(SlobodniTerminiUputSpecijalistiDTO podaci)
        {
            List<Pregled> ZakazaniPreglediDoktora = pregledRepository.DobaviZakazanePregledeDoktora(podaci.IzabraniDoktor);
            List<Pregled> zauzetiPreglediZaInterval = ZauzetostPregledaZaInterval(podaci.Datumi, ZakazaniPreglediDoktora);

            List<DateTime> slobodniTermini = RacunanjeSlobodnihTermina(zauzetiPreglediZaInterval, podaci);
            return slobodniTermini;
        }

        public List<DateTime> RacunanjeSlobodnihTermina(List<Pregled> zauzetiPregledi, SlobodniTerminiUputSpecijalistiDTO podaci)
        {

            List<DateTime> slobodniTermini = new List<DateTime>();

            for (DateTime datum = podaci.Datumi.PocetnoVrijeme; datum <= podaci.Datumi.KrajnjeVrijeme; datum = datum.AddDays(1))
            {
                slobodniTermini.AddRange(DodavanjeSlobodnihTermina(zauzetiPregledi, podaci.Sati, datum));
            }

            return slobodniTermini;
        }
        private List<DateTime> DodavanjeSlobodnihTermina(List<Pregled> zauzetiPregledi, IntervalSati sati, DateTime datum)
        {
            List<DateTime> slobodniTermini = new List<DateTime>();
            DateTime pocetak = new DateTime(datum.Year, datum.Month, datum.Day, sati.PocetniInterval, 0, 0);
            DateTime kraj = new DateTime(datum.Year, datum.Month, datum.Day, sati.KrajnjiInterval, 0, 0);

            for (DateTime terminPocetak = pocetak; terminPocetak < kraj; terminPocetak = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA))
            {
                int zauzet = 0;
                IntervalDatuma termin = new IntervalDatuma(terminPocetak, terminPocetak.AddMinutes(TRAJANJE_PREGLEDA));
                //  DateTime terminKraj = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA);
                zauzet = ProvjeravanjeZauzetostiTermina(zauzetiPregledi, zauzet, termin);

                if (zauzet == 0)
                    slobodniTermini.Add(terminPocetak);
            }
            return slobodniTermini;
        }

        private static int ProvjeravanjeZauzetostiTermina(List<Pregled> zauzetiPregledi, int zauzet, IntervalDatuma termin)
        {
            foreach (Pregled p in zauzetiPregledi)
            {
                zauzet = ProvjeravanjePodudaranjaTerminaSaPregledom(zauzet, p, termin);
            }

            return zauzet;
        }
        private static int ProvjeravanjePodudaranjaTerminaSaPregledom(int zauzet, Pregled p, IntervalDatuma termin)
        {
            if (DateTime.Compare(termin.PocetnoVrijeme, p.Pocetak) >= 0 && DateTime.Compare(termin.PocetnoVrijeme, p.Pocetak.AddMinutes(p.Trajanje)) < 0 ||
                DateTime.Compare(termin.KrajnjeVrijeme, p.Pocetak) > 0 && DateTime.Compare(termin.KrajnjeVrijeme, p.Pocetak.AddMinutes(p.Trajanje)) <= 0)
                zauzet++;
            return zauzet;
        }

        private static List<Pregled> ZauzetostPregledaZaInterval(IntervalDatuma interval, List<Pregled> ZakazaniPreglediDoktora)
        {
            List<Pregled> zauzetiPreglediZaInterval = new List<Pregled>();
            foreach (Pregled p in ZakazaniPreglediDoktora)
            {
                if (p.Pocetak.Date >= interval.PocetnoVrijeme.Date && p.Pocetak.Date <= interval.KrajnjeVrijeme.Date)
                    zauzetiPreglediZaInterval.Add(p);
            }

            return zauzetiPreglediZaInterval;
        }

        public List<DateTime> PronadjiNoveTermine(SlobodniTerminiUputSpecijalistiDTO podaci)
        {

            List<Pregled> ZakazaniPreglediDoktora = pregledRepository.DobaviZakazanePregledeDoktora(podaci.IzabraniDoktor);
            List<Pregled> zauzetiPreglediZaInterval = ZauzetostPregledaZaInterval(podaci.Datumi, ZakazaniPreglediDoktora);

            IntervalDatuma inetrvalPrije=RacunanjeVremenaOkoIntervalaPrije(podaci.Datumi);
            IntervalDatuma inetrvalPoslije= RacunanjeVremenaOkoIntervalaPoslije(podaci.Datumi);
            
            List<DateTime> slobodniTermini = RacunanjeSlobodnihTermina(zauzetiPreglediZaInterval, new SlobodniTerminiUputSpecijalistiDTO(podaci.IzabraniDoktor, inetrvalPrije, podaci.Sati));
            slobodniTermini.AddRange(RacunanjeSlobodnihTermina(zauzetiPreglediZaInterval, new SlobodniTerminiUputSpecijalistiDTO(podaci.IzabraniDoktor, inetrvalPoslije, podaci.Sati)));
           
            List<KeyValuePair<int, DateTime>> parUdaljenostTermin = new List<KeyValuePair<int, DateTime>>();
            parUdaljenostTermin = UdaljenostiOdZadatogVremena(parUdaljenostTermin, podaci.Datumi.PocetnoVrijeme, slobodniTermini);
          
            return IzlistavanjeNajblizihTermina(parUdaljenostTermin);

        }

        private static IntervalDatuma RacunanjeVremenaOkoIntervalaPrije(IntervalDatuma interval)
        {

            DateTime pocetnoVrijeme = interval.PocetnoVrijeme.AddDays(-2);
            DateTime krajnjeVrijeme = interval.PocetnoVrijeme.AddDays(-1);
            IntervalDatuma noviInterval = new IntervalDatuma(interval.PocetnoVrijeme, interval.KrajnjeVrijeme);
            return noviInterval;


        }

        private static IntervalDatuma RacunanjeVremenaOkoIntervalaPoslije(IntervalDatuma interval)
        {
            DateTime pocetnoVrijeme = interval.PocetnoVrijeme.AddDays(1);
            DateTime krajnjeVrijeme = interval.PocetnoVrijeme.AddDays(2);
            IntervalDatuma noviInterval = new IntervalDatuma(interval.PocetnoVrijeme, interval.KrajnjeVrijeme);
            return noviInterval;
        }

        private static List<DateTime> IzlistavanjeNajblizihTermina(List<KeyValuePair<int, DateTime>> parUdaljenostTermin)
        {
            List<DateTime> slobodniTermini = new List<DateTime>();
            parUdaljenostTermin.Sort((x, y) => x.Key.CompareTo(y.Key));

            for (int i = 1; i < 100; i++)
            {
                if (parUdaljenostTermin.Count < i + 1)
                    break;
                slobodniTermini.Add(parUdaljenostTermin[i].Value);
            }

            List<DateTime> sortiraniSlobodniTermini = slobodniTermini.OrderBy(o => o).ToList();

            return sortiraniSlobodniTermini;
        }

        private static List<KeyValuePair<int, DateTime>> UdaljenostiOdZadatogVremena(List<KeyValuePair<int, DateTime>> parUdaljenostTermin, DateTime pocetnoVrijeme, List<DateTime> slobodniTermini)
        {

            foreach (DateTime t in slobodniTermini)
            {
                int distanca = (int)((t - pocetnoVrijeme.AddHours(2)).Duration()).TotalSeconds;

                parUdaljenostTermin.Add(new KeyValuePair<int, DateTime>(distanca, t));
            }

            return parUdaljenostTermin;
        }


    }
}

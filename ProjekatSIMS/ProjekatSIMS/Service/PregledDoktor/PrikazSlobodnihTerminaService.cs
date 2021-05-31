using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PrikazSlobodnihTerminaService
    {
        private PregledRepository pregledRepository = new PregledRepository();
        public List<String> PrikazTermina(Pregled pregled, IntervalDatuma termin)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledeDoktor();
            List<Pregled> preglediUIstoVrijeme = PreglediUIstiDan(pregled, pregledi, termin);
            List<DateTime> slobodniTermini = DobavljanjeSLobodnihTermina(termin, preglediUIstoVrijeme, pregled);
            List<KeyValuePair<int, DateTime>> parovi = RacunanjeUdaljenostiTermina(slobodniTermini, termin);

            return NajbliziTermini(parovi);

        }

        private static List<string> NajbliziTermini(List<KeyValuePair<int, DateTime>> parovi)
        {
            List<String> konacniTermini = new List<String>();
            //izlistavam 4 najbliza termina izabranom
            for (int i = 1; i < 5; i++)
            {
                if (parovi.Count < i + 1)
                    break;
                konacniTermini.Add(parovi[i].Value.Hour + ":" + parovi[i].Value.Minute);
            }
            return konacniTermini;
        }

        public List<KeyValuePair<int, DateTime>> RacunanjeUdaljenostiTermina(List<DateTime> termini, IntervalDatuma termin)
        {
            List<KeyValuePair<int, DateTime>> parovi = new List<KeyValuePair<int, DateTime>>();
            foreach (DateTime t in termini)
            {
                int distanca = (int)((t - termin.PocetnoVrijeme).Duration()).TotalSeconds;
                parovi.Add(new KeyValuePair<int, DateTime>(distanca, t));
            }
            parovi.Sort((x, y) => x.Key.CompareTo(y.Key));
            return parovi;
        }

        private static List<DateTime> DobavljanjeSLobodnihTermina(IntervalDatuma termin, List<Pregled> preglediUIstoVrijeme, Pregled pregled)
        {
            List<DateTime> termini = new List<DateTime>();
            DateTime pocetni = new DateTime(termin.PocetnoVrijeme.Year, termin.PocetnoVrijeme.Month, termin.PocetnoVrijeme.Day, 8, 0, 0);
            DateTime krajnji = new DateTime(termin.KrajnjeVrijeme.Year, termin.KrajnjeVrijeme.Month, termin.KrajnjeVrijeme.Day, 20, 0, 0);

            for (DateTime datum = pocetni; datum < krajnji; datum = datum.AddMinutes(pregled.Trajanje))
            {
                int znak = ZauzetiTermini(preglediUIstoVrijeme, pregled, datum);
                if (znak == 0)
                    termini.Add(datum);


            }

            return termini;
        }

        private static int ZauzetiTermini(List<Pregled> preglediUIstoVrijeme, Pregled pregled, DateTime i1)
        {
            int znak = 0;
            DateTime i2 = i1.AddMinutes(pregled.Trajanje);
            foreach (Pregled p in preglediUIstoVrijeme)
            {
                DateTime datum11 = p.Pocetak;
                DateTime datum22 = p.Pocetak.AddMinutes(p.Trajanje);
                if (DateTime.Compare(i1, datum11) >= 0 && DateTime.Compare(i1, datum22) < 0 ||
                    DateTime.Compare(i2, datum11) > 0 && DateTime.Compare(i2, datum22) <= 0)
                    znak++;

            }

            return znak;
        }

        private List<Pregled> PreglediUIstiDan(Pregled pregled, List<Pregled> pregledi, IntervalDatuma termin)
        {
            List<Pregled> preglediUIstoVrijeme = new List<Pregled>();
            foreach (Pregled p in pregledi)
            {
                if (p.StatusPregleda == StatusPregleda.Zakazan)
                {
                    if (pregled.doktor.Jmbg == p.doktor.Jmbg || p.prostorija == pregled.prostorija)
                    {
                        if (p.Pocetak.Date.CompareTo(termin.PocetnoVrijeme.Date) == 0)
                            preglediUIstoVrijeme.Add(p);

                    }
                }
            }
            return preglediUIstoVrijeme;
        }
    }
}

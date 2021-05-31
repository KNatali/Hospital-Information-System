using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ZauzetostTerminaPregledaService
    {
        private PregledRepository pregledRepository = new PregledRepository();
        public Boolean ProvjeraZauzetostiTermina(Pregled pregled, IntervalDatuma termin)
        {
            List<Pregled> pregledi = new List<Pregled>();
            pregledi = pregledRepository.DobaviSvePregledeDoktor();
            foreach (Pregled p in pregledi)
            {

                if (p.StatusPregleda == StatusPregleda.Zakazan)
                {
                    if (PreklapanjeTermina(pregled, p, termin))
                        return true;
                }
            }

            return false;

        }

        public Boolean PreklapanjeTermina(Pregled pregled, Pregled zakazanPregled, IntervalDatuma termin)
        {
            if ((pregled.doktor.Jmbg == zakazanPregled.doktor.Jmbg || zakazanPregled.prostorija == pregled.prostorija) && zakazanPregled.Pocetak.Date.CompareTo(termin.PocetnoVrijeme.Date) == 0)
            {
                if (IsIspunjenoPreklapanje(zakazanPregled, termin))
                    return true;
            }
            return false;
        }

        private static bool IsIspunjenoPreklapanje(Pregled zakazanPregled, IntervalDatuma termin)
        {
            return (DateTime.Compare(termin.PocetnoVrijeme, zakazanPregled.Pocetak) >= 0 && DateTime.Compare(termin.PocetnoVrijeme, zakazanPregled.Pocetak.AddMinutes(zakazanPregled.Trajanje)) < 0 ||
                    DateTime.Compare(termin.KrajnjeVrijeme, zakazanPregled.Pocetak) > 0 && DateTime.Compare(termin.KrajnjeVrijeme, zakazanPregled.Pocetak.AddMinutes(zakazanPregled.Trajanje)) <= 0 ||
                    DateTime.Compare(termin.PocetnoVrijeme, zakazanPregled.Pocetak) <= 0 && DateTime.Compare(termin.KrajnjeVrijeme, zakazanPregled.Pocetak.AddMinutes(zakazanPregled.Trajanje)) >= 0 );
        }

       
    }
}

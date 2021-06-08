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
            pregledi = pregledRepository.DobaviZakazanePreglede();
            foreach (Pregled p in pregledi)
            {
                if (PreklapanjeTermina(pregled, p, termin))
                    return true;

            }

            return false;

        }

        public Boolean PreklapanjeTermina(Pregled pregled, Pregled zakazanPregled, IntervalDatuma termin)
        {
            if ((pregled.doktor.Jmbg == zakazanPregled.doktor.Jmbg || zakazanPregled.prostorija == pregled.prostorija) && zakazanPregled.Pocetak.Date.CompareTo(termin.PocetnoVrijeme.Date) == 0)
            {
                IntervalDatuma termin2 = new IntervalDatuma(pregled.Pocetak, pregled.Pocetak.AddMinutes(pregled.Trajanje));
                if (termin.DaLiSeTerminiPoklapaju(termin2))
                    return true;
            }
            return false;
        }

       

    }
}

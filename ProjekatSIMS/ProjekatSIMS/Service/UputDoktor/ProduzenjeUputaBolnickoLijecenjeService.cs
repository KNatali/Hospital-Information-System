using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProduzenjeUputaBolnickoLijecenjeService
    {

         private UputBolnickoLijecenjeRepository uputRepository = new UputBolnickoLijecenjeRepository();
       

        public bool IsProduzavanjeMoguce(UputBolnickoLijecenje uput, DateTime krajIntervala)
        {
            List<UputBolnickoLijecenje> sviUputi = uputRepository.DobaviSveUpute();
            IntervalDatuma termin1 = new IntervalDatuma(uput.Interval.PocetnoVrijeme, krajIntervala);
            foreach (UputBolnickoLijecenje u in sviUputi)
            {
                IntervalDatuma termin2 = new IntervalDatuma(u.Interval.PocetnoVrijeme, u.Interval.KrajnjeVrijeme);
                if (termin1.DaLiSeTerminiPoklapaju(termin2))
                {
                    if (!(uput.Interval.PocetnoVrijeme == u.Interval.PocetnoVrijeme && uput.Interval.KrajnjeVrijeme == u.Interval.KrajnjeVrijeme && uput.KrevetId == u.KrevetId))
                        return false;
                }


            }
            return true;
        }

        public void ProduzavanjeUputa(UputBolnickoLijecenje uput, DateTime krajIntervala, Pacijent pacijent)
        {
            List<UputBolnickoLijecenje> sviUputi = uputRepository.DobaviSveUpute();
            sviUputi = AzuriranjeUputa(sviUputi, uput, krajIntervala);
            uputRepository.SacuvajUpute(sviUputi);
   }

        public List<UputBolnickoLijecenje> AzuriranjeUputa(List<UputBolnickoLijecenje> uputi, UputBolnickoLijecenje uput, DateTime krajIntervala)
        {

            foreach (UputBolnickoLijecenje u in uputi)
            {
                if (u.Id==uput.Id)
                {
                    u.Interval.KrajnjeVrijeme = krajIntervala;
                    break;
                }
            }

            return uputi;
        }

    }
}

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
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();

        public bool IsProduzavanjeMoguce(UputBolnickoLijecenje uput, DateTime krajIntervala)
        {
            List<UputBolnickoLijecenje> sviUputi = uputRepository.DobaviSveUpute();

            foreach (UputBolnickoLijecenje u in sviUputi)
            {
                if ((DateTime.Compare(uput.Interval.PocetnoVrijeme, u.Interval.PocetnoVrijeme) >= 0 && DateTime.Compare(uput.Interval.PocetnoVrijeme, u.Interval.KrajnjeVrijeme) < 0 ||
                     DateTime.Compare(krajIntervala, u.Interval.PocetnoVrijeme) > 0 && DateTime.Compare(krajIntervala, u.Interval.KrajnjeVrijeme) <= 0 ||
                     DateTime.Compare(uput.Interval.PocetnoVrijeme, u.Interval.PocetnoVrijeme) <= 0 && DateTime.Compare(krajIntervala, u.Interval.KrajnjeVrijeme) >= 0) && u.KrevetId == uput.KrevetId)
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

           /* ZdravsteniKarton karton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            karton.UputiZaBolnickoLijecenje = AzuriranjeUputa(karton.UputiZaBolnickoLijecenje, uput, krajIntervala);
            zdravstveniKartonRepository.AzurirajKarton(karton);*/

         }

        public List<UputBolnickoLijecenje> AzuriranjeUputa(List<UputBolnickoLijecenje> uputi, UputBolnickoLijecenje uput, DateTime krajIntervala)
        {

            foreach (UputBolnickoLijecenje u in uputi)
            {
                if (u.Interval.PocetnoVrijeme == uput.Interval.PocetnoVrijeme && u.Interval.KrajnjeVrijeme == uput.Interval.KrajnjeVrijeme && u.KrevetId == uput.KrevetId)
                {
                    u.Interval.KrajnjeVrijeme = krajIntervala;
                    break;
                }
            }

            return uputi;
        }

    }
}

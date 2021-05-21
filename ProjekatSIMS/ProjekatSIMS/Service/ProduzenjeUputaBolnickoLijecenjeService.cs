using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProduzenjeUputaBolnickoLijecenjeService
    {
        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        private UputBolnickoLijecenjeRepository uputRepository = new UputBolnickoLijecenjeRepository();
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();

        public bool IsProduzavanjeMoguce(UputBolnickoLijecenje uput, DateTime krajIntervala)
        {
            List<UputBolnickoLijecenje> sviUputi = uputRepository.DobaviSveUpute();

            foreach (UputBolnickoLijecenje u in sviUputi)
            {
                if ((DateTime.Compare(uput.IntervalPocetak, u.IntervalPocetak) >= 0 && DateTime.Compare(uput.IntervalPocetak, u.IntervalKraj) < 0 ||
                     DateTime.Compare(krajIntervala, u.IntervalPocetak) > 0 && DateTime.Compare(krajIntervala, u.IntervalKraj) <= 0) && u.KrevetId == uput.KrevetId)
                {
                    if (!(uput.IntervalPocetak == u.IntervalPocetak && uput.IntervalKraj == u.IntervalKraj && uput.KrevetId == u.KrevetId))
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

            ZdravsteniKarton karton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            karton.UputiZaBolnickoLijecenje = AzuriranjeUputa(karton.UputiZaBolnickoLijecenje, uput, krajIntervala);
            zdravstveniKartonRepository.AzurirajKarton(karton);




        }

        public List<UputBolnickoLijecenje> AzuriranjeUputa(List<UputBolnickoLijecenje> uputi, UputBolnickoLijecenje uput, DateTime krajIntervala)
        {

            foreach (UputBolnickoLijecenje u in uputi)
            {
                if (u.IntervalPocetak == uput.IntervalPocetak && u.IntervalKraj == uput.IntervalKraj && u.KrevetId == uput.KrevetId)
                {
                    u.IntervalKraj = krajIntervala;
                    break;
                }
            }

            return uputi;
        }
    }
}

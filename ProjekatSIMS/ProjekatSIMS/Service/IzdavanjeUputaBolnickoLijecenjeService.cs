using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class IzdavanjeUputaBolnickoLijecenjeService
    {
        private UputBolnickoLijecenjeRepository uputRepository = new UputBolnickoLijecenjeRepository();
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        public void CuvanjeUputa(UputBolnickoLijecenje uput, Pacijent pacijent)
        {
            uputRepository.SacuvajUput(uput);
            DodavanjeUputaUZdravstveniKarton(uput, pacijent);
        }

        public void DodavanjeUputaUZdravstveniKarton(UputBolnickoLijecenje uput, Pacijent pacijent)
        {
            ZdravsteniKarton zdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);

            if (zdravstveniKarton.UputiZaBolnickoLijecenje == null)
                zdravstveniKarton.UputiZaBolnickoLijecenje = new List<UputBolnickoLijecenje>();
            zdravstveniKarton.UputiZaBolnickoLijecenje.Add(uput);
            zdravstveniKartonRepository.AzurirajKarton(zdravstveniKarton);
        }
    }
}

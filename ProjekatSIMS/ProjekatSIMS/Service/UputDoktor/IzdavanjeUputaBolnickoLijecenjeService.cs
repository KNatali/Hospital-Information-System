using Model;
using ProjekatSIMS.DTO;
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
        public void CuvanjeUputa(UputBolnickoLijecenjeDTO uput, Pacijent pacijent)
        {
            List<UputBolnickoLijecenje> sviUputi = uputRepository.DobaviSveUpute();
            UputBolnickoLijecenje noviUput = new UputBolnickoLijecenje(GenerisiId(sviUputi), uput.Interval,uput.SobaId, uput.KrevetId, uput.IdKartona);
            uputRepository.SacuvajUput(noviUput);
            DodavanjeUputaUZdravstveniKarton(noviUput, pacijent);
        }
        public int GenerisiId(List<UputBolnickoLijecenje> uputi)
        {
            if (uputi.Count == 0)
                return 1;

            else
                return uputi[uputi.Count - 1].Id + 1;

        }

        public void DodavanjeUputaUZdravstveniKarton(UputBolnickoLijecenje uput, Pacijent pacijent)
        {
            ZdravsteniKarton zdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);

            if (zdravstveniKarton.UputiZaBolnickoLijecenje == null)
                zdravstveniKarton.UputiZaBolnickoLijecenje = new List<int>();
            zdravstveniKarton.UputiZaBolnickoLijecenje.Add(uput.Id);
            zdravstveniKartonRepository.AzurirajKarton(zdravstveniKarton);
        }
    }
}

using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AlergijeNaLijekService
    {

        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        public Boolean IsPacijentAlergican(Lijek izabraniLijek, Pacijent pacijent)
        {
            List<ZdravsteniKarton> zdravstveniKartoni = zdravstveniKartonRepository.DobaviZdravstveneKartone();
            List<String> alergeniPacijenta = new List<String>();
            alergeniPacijenta = DobavljanjeAlergenaPacijenta(zdravstveniKartoni, pacijent);
            if (ProvjeraAlergena(izabraniLijek, alergeniPacijenta))
                return true;

            return false;
        }

        private Boolean ProvjeraAlergena(Lijek lijek, List<string> alergeni)
        {
            if (lijek.Alergeni != null)
            {
                foreach (String s in lijek.Alergeni)
                {
                    if (alergeni.Contains(s))
                        return true;
                }
            }
            return false;
        }

        private List<string> DobavljanjeAlergenaPacijenta(List<ZdravsteniKarton> kartoni, Pacijent pacijent)
        {

            List<String> alergeni = new List<String>();
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.IdPacijent == pacijent.Jmbg)
                {
                    if (k.Alergeni != null)
                    {
                        alergeni = k.Alergeni;
                        break;
                    }
                }
            }

            return alergeni;
        }
    }
}

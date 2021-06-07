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

            List<String> alergeniPacijenta = zdravstveniKartonRepository.DobaviAlergene(pacijent);
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

       
    }
}

using Repository;
using System;
using Model;
using System.Collections.Generic;

namespace Service
{
   public class ZdravstvenikartonService
   {
        public Repository.ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository(@"..\..\..\Fajlovi\ZdravstveniKarton.txt");
        public Boolean kreiranjeAlergena(String alergen, Pacijent p)
        {
            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg == p.Jmbg)
                {
                    if (k.Alergeni == null)
                        k.Alergeni.Add(alergen);
                    else
                        k.Alergeni.Add(alergen);
                }
            }
            return true;
        }
        public List<String> DobaviSveAlergene()
        {
            return zdravstveniKartonRepository.DobaviSveAlergene();
        }
      
   
   
   }
}
using Repository;
using System;
using Model;
using System.Collections.Generic;

namespace Service
{
   public class ZdravstvenikartonService
   {
        public Repository.ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository(@"..\..\..\Fajlovi\ZdravstveniKarton.txt");
        public void kreiranjeAlergena(String alergen, Pacijent pacijent)
        {
            ZdravsteniKarton zdravstveniKarton = new ZdravsteniKarton();
            zdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            zdravstveniKarton.Alergeni.Add(alergen);
            zdravstveniKartonRepository.AzurirajKarton(zdravstveniKarton);
        }
        
        public List<String> DobaviSveAlergene(Pacijent pacijent)
        {
            ZdravsteniKarton zdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            List<string> sviAlergeniPacijenta = new List<string>();
            if(zdravstveniKarton.Alergeni!=null)
                sviAlergeniPacijenta = zdravstveniKarton.Alergeni;
            return sviAlergeniPacijenta;
        }

      
   

   
   }
}
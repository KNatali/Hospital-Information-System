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
            ZdravsteniKarton zk = new ZdravsteniKarton();
            zk = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            zk.Alergeni.Add(alergen);
            zdravstveniKartonRepository.AzurirajKarton(zk);
        }
        
        public List<String> DobaviSveAlergene(Pacijent pacijent)
        {
            ZdravsteniKarton zk = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            List<string> Alergeni = new List<string>();
            if(zk.Alergeni!=null)
            {
                Alergeni = zk.Alergeni;
            }
            return Alergeni;
        }
        public void PregledKartona()
      {
         // TODO: implement
      }
      
      public Model.Anamneza KreiranjeAnamneze()
      {
         // TODO: implement
         return null;
      }
      
      public Model.Recept IzdavanjeRecepta()
      {
         // TODO: implement
         return null;
      }
      
      public Model.Anamneza IzmenaAnamneze()
      {
         // TODO: implement
         return null;
      }
      
      public List<String> AzuriranjeAlergena()
      {
         // TODO: implement
         return null;
      }
   
      public Repository.ReceptRepository receptRepository;
      public Repository.AnamnezaRepository anamnezaRepository;
   
   }
}
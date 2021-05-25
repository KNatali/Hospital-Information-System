using Service;
using System;
using Model;
using System.Collections.Generic;

namespace Controller
{
   public class ZdravstvenikartonController
   {
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
   
      public Service.ZdravstvenikartonService zdravstvenikartonService = new ZdravstvenikartonService();
        public void kreiranjeAlergena(String alergen, Pacijent p)
        {
            zdravstvenikartonService.kreiranjeAlergena(alergen, p);
        }
        public List<String> DobaviSveAlergene(Pacijent pacijent)
        {
            return zdravstvenikartonService.DobaviSveAlergene(pacijent);
        }
    }
}
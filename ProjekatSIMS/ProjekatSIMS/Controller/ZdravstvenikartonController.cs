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
        public Boolean kreiranjeAlergena(String alergen, Pacijent p)
        {
            if (zdravstvenikartonService.kreiranjeAlergena(alergen,p) == true)
                return true;
            else
                return false;
        }
    }
}
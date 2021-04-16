using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class PregledController
   {
      public Model.Pregled ZakaziGuestPregledController(DateTime datumPregleda, Model.Pacijent pacijent)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Pregled ZakazivanjeOperacije()
      {
         // TODO: implement
         return null;
      }
      
      public Model.Pregled ZakazivanjePregleda()
      {
         // TODO: implement
         return null;
      }
      
      public List<Pregled> GetListaPregledaController(DateTime zaDan)
      {
         // TODO: implement
         return null;
      }
      
      public List<Pregled> GetListaPregledaController(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean ProveraTerminaController(DateTime datumVreme)
      {
         // TODO: implement
         return true;
      }
      
      public Model.Pregled IzmenaPregledaPacijent(Model.Pregled pregled)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean SlobodanTerminPacijent()
      {
         // TODO: implement
         return true;
      }
   
      public Service.PregledService pregledService;
   
   }
}
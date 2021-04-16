using Model;
using System;
using System.Collections.Generic;

namespace Service
{
   public class PregledService
   {
      public Model.Pregled ZakaziGuestPregledService(DateTime datumPregleda, Model.Pacijent pacijent)
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
      
      public List<Pregled> GetListaPregledaService(DateTime zaDan)
      {
         // TODO: implement
         return null;
      }
      
      public List<Pregled> GetListaPregledaService(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean ProveraTerminaService(DateTime datumVreme)
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
   
      public Repository.PregledRepository pregledRepository;
   
   }
}
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Controller
{
   public class PregledController

      
   {

        public Service.PregledService pregledService = new PregledService();
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
      
      public Boolean ZakazivanjePregleda(ComboBox Termin,String jmbg,Prostorija prostorija,DateTime datum1,DateTime datum2)
      {
           
            if (pregledService.ZakazivanjePregleda(Termin,jmbg, prostorija, datum1, datum2))
                return true;

            return false;

      }

        public Boolean OtkazivanjePregledaDoktor(Pregled p)
        {
            if (pregledService.OtkazivanjePregledaDoktor(p))
                return true;

            return false;

        }

        public Boolean IzmjenaPregledaDoktor(Pregled p,DateTime datum)
        {
            if (pregledService.IzmjenaPregledaDoktor(p,datum))
                return true;

            return false;

        }

        public List<Pregled> DobaviSvePreglede()
        {
           return pregledService.DobaviSvePreglede();

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

        public Boolean ZakazivanjePregledaPacijent(String ime, String prezime, String imeDoktora, String prezimeDoktora, DateTime datum, String jmbg)
        {

            if (pregledService.ZakazivanjePregledaPacijent(ime, prezime, imeDoktora,prezimeDoktora,datum,jmbg))
                return true;

            return false;

        }
        public Boolean DaLiJeTerminZauzet()
        {
            if(pregledService.OdredjivanjePrioritetaPacijent() == true)
            {
                return true;
            }
            return false;
        }

    }
}
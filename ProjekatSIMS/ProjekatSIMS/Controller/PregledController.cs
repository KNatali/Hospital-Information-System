using Model;
using ProjekatSIMS.Service;
using ProjekatSIMS.Service.PreglediPacijent;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Controller
{
   public class PregledController

      
   {

        public Service.PregledService pregledService = new PregledService();
        public ZakazivanjePregledaService zakazivanjePregledaService = new ZakazivanjePregledaService();
        public PregledRepository pregledRepository = new PregledRepository();

        public ZauzetiTerminiService zauzetiTermini = new ZauzetiTerminiService();
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

        public Boolean ZakazivanjePregledaSekretar(ComboBox Termin, String jmbg, String jmbgdoktor,Prostorija prostorija, DateTime datum1, DateTime datum2)
        {

            if (pregledService.ZakazivanjePregledaSekretar(Termin, jmbg, jmbgdoktor, prostorija, datum1, datum2))
                return true;

            return false;

        }
        

       
        public Boolean OtkazivanjeSekretar(Pregled p)
        {
            if (pregledService.OtkazivanjeSekretar(p))
                return true;
            return false;
        }
      

       

      
     public List<Pregled> DobaviSveSekretar()
     {
         return pregledService.DobaviSveSekretar();
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

       /* public Boolean ZakazivanjePregledaPacijent(String ime, String prezime, String imeDoktora, String prezimeDoktora, DateTime datum, String jmbg)
        {

            if (pregledService.ZakazivanjePregledaPacijent(ime, prezime, imeDoktora,prezimeDoktora,datum,jmbg))
                return true;

            return false;

        } */
        public Boolean ZakazivanjePregledaPacijent( String imeDoktora, String prezimeDoktora, DateTime datum, Pacijent pac)
        {

            if (zakazivanjePregledaService.ZakazivanjePregledaPacijent(imeDoktora, prezimeDoktora, datum, pac))
                return true;

            return false;

        }
        public Boolean DaLiJeTerminZauzet(DateTime datum)
        {
            if(zauzetiTermini.DaLiJeTerminZauzet(datum))
            {
                return true;
            }
            return false;
        }

        public List<Pregled> DobaviPregledeZaPacijenta(Pacijent pacijent)
        {
            return pregledRepository.DobaviPregledeZaPacijenta(pacijent);
        }
        public ObservableCollection<Pregled> DobaviPregledeZaPacijentaOC(Pacijent pacijent)
        {
            return pregledRepository.DobaviPregledeZaPacijentaOC(pacijent);
        }
    }
}
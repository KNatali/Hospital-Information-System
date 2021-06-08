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

        public Boolean IzmenaPregledaSekretar(Pregled p, DateTime datum)
        {
            if (pregledService.IzmenaPregledaSekretar(p, datum))
                return true;
            return false;
        }



        public List<Pregled> DobaviSveSekretar()
     {
         return pregledService.DobaviSveSekretar();
     }
      

   
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
      
    
     

     
    

       
        

    }
}
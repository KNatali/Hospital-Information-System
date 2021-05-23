using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class NotifikacijaController
   {
        public Service.NotifikacijaService notifikacijaService = new NotifikacijaService();
        public void PosaljiNotifikacijuPacijent()
      {
         // TODO: implement
      }
      
      public void PosaljiNotifikacijuSekretar()
      {
         // TODO: implement
      }
        public List<Notifikacija> DobaviSve()
        {
            return notifikacijaService.DobaviSve();
        }
        public Boolean pisanjeObavestenja(String naslov, String tekst, DateTime datumObjavljivanja)
        {
            if (notifikacijaService.pisanjeObavestenja(naslov,tekst,datumObjavljivanja) == true)
                return true;
            else
                return false;
        }
    }
}
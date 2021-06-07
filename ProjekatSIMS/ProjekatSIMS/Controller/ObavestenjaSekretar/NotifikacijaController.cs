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
        public Boolean PisanjeObavestenja(Notifikacija notifikacija)
        {
            if (notifikacijaService.PisanjeObavestenja(notifikacija) == true)
                return true;
            else
                return false;
        }
        public Boolean CuvanjeIzmenjenjihPodataka(Notifikacija stariPodaci)
        {
            if (notifikacijaService.CuvanjeIzmenjenjihPodataka(stariPodaci))
                return true;
            else
                return false;
        }
        public Boolean ObrisiObavestenje(Notifikacija notifikacija)
        {
            if (notifikacijaService.ObrisiObavestenje(notifikacija))
                return true;
            else
                return false;
        }
    }
}
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
   public  class ManipulacijaPregledomController
    {
        private ManipulacijaPregledomService zakaziPregledService = new ManipulacijaPregledomService();

        public void ZakaziPregled(Pregled pregled)
        {
            zakaziPregledService.ZakaziPregled(pregled);
        }

        public void IzmjeniPregled(Pregled stariPregled, DateTime noviTermin)
        {
            zakaziPregledService.IzmjeniPregled(stariPregled, noviTermin);
        }
    }
}

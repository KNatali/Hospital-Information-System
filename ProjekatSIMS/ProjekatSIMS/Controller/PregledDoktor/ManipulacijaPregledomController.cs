using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
   public  class ManipulacijaPregledomController
    {
        private ManipulacijaPregledomService manipulacijaPregledomService = new ManipulacijaPregledomService();

        public void ZakaziPregled(Pregled pregled)
        {
            manipulacijaPregledomService.CuvanjePregleda(pregled);
        }

        public void IzmjeniPregled(Pregled stariPregled, DateTime noviTermin)
        {
            manipulacijaPregledomService.IzmjeniPregled(stariPregled, noviTermin);
        }

        public void OtkazivanjePregleda(Pregled pregled)
        {
            manipulacijaPregledomService.OtkazivanjePregleda(pregled);
        }
    }
}

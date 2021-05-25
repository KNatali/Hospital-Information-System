using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
   public  class ZakaziPregledDoktorController
    {
        private ZakaziPregledDoktorService zakaziPregledService = new ZakaziPregledDoktorService();

        public void ZakaziPregled(Pregled pregled)
        {
            zakaziPregledService.ZakaziPregled(pregled);
        }
    }
}

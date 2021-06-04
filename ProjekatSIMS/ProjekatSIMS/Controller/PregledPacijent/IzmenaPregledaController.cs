using Model;
using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.PregledPacijent
{
   public  class IzmenaPregledaController
    {
        public IzmenaPregledaService izmenaPregledaService = new IzmenaPregledaService();

        public Boolean IzmeniPregled(DateTime noviDatum,Pregled p)
        {
            if (izmenaPregledaService.IzmeniPregled(noviDatum, p) == true)
                return true;
            else
                return false;
        }
        public int ProveraZauzetostiTermina(DateTime noviDatum)
        {
            if (izmenaPregledaService.ProveraZauzetostiTermina(noviDatum) == 1)
                return 1;
            else
                return 0;
        }
    }
}

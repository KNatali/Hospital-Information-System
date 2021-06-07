using Model;
using ProjekatSIMS.Service;
using ProjekatSIMS.Service.PreglediPacijent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.PregledPacijent
{
   public  class IzmenaPregledaController
    {
        public IzmenaPregledaService izmenaPregledaService = new IzmenaPregledaService();

        public ZauzetiTerminiService zauzetiTermini = new ZauzetiTerminiService();

        public Boolean IzmeniPregled(DateTime noviDatum,Pregled p)
        {
            if (izmenaPregledaService.IzmeniPregled(noviDatum, p) == true)
                return true;
            else
                return false;
        }
        public int ProveraZauzetostiTermina(DateTime noviDatum)
        {
            if (zauzetiTermini.DaLiJeTerminZauzet(noviDatum) == true)
                return 1;
            else
                return 0;
        }
    }
}

using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class ZauzetostTerminaPregledaController
    {
        private ZauzetostTerminaPregledaService pomjeriPregledDoktorService = new ZauzetostTerminaPregledaService();
   public Boolean PomjeriPregled(Pregled pregled,IntervalDatuma termin)
        {
           return  pomjeriPregledDoktorService.ProvjeraZauzetostiTermina(pregled, termin);
        }
    }
}

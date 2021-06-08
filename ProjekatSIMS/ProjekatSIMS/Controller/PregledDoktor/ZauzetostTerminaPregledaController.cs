using Model;
using Service;
using System;

namespace Controller
{
    public class ZauzetostTerminaPregledaController
    {
        private ZauzetostTerminaPregledaService pomjeriPregledDoktorService = new ZauzetostTerminaPregledaService();
        public Boolean ProvjeraZauzetostiTermina(Pregled pregled, IntervalDatuma termin)
        {
            return pomjeriPregledDoktorService.ProvjeraZauzetostiTermina(pregled, termin);
        }
    }
}

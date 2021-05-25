using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class PrikazSlobodnihTerminaController
    {
        private PrikazSlobodnihTerminaService prikazSlobodnihTerminaService = new PrikazSlobodnihTerminaService();
   
        public List<String> PrikazTermina(Pregled pregled, IntervalDatuma termin)
        {
            return prikazSlobodnihTerminaService.PrikazTermina(pregled, termin);
        }
    }
}

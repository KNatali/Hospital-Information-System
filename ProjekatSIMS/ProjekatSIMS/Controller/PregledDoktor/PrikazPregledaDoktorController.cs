using Model;
using ProjekatSIMS.Service.PregledDoktor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.PregledDoktor
{
    public class PrikazPregledaDoktorController
    {
        private PrikazPregledaDoktorService prikazPregledaDoktorService = new PrikazPregledaDoktorService();

        public List<Pregled> PrikazPregleda()
        {
            return prikazPregledaDoktorService.PrikazPregleda();
        }
    }
}

using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class PrikazAnamnezaZaPacijentaController
    {
        private PrikazAnamnezaZaPacijentaService prikazAnamnezaZaPacijentaService = new PrikazAnamnezaZaPacijentaService();
   
        public List<Anamneza> PrikazAnamneza(Pacijent pacijent)
        {
            return prikazAnamnezaZaPacijentaService.PrikazAnamneza(pacijent);
        }
    }
}

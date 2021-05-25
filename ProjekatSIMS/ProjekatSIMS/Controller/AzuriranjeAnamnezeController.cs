using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class AzuriranjeAnamnezeController
    {
        private AzuriranjeAnamnezeService azuriranjeAnamnezeService = new AzuriranjeAnamnezeService();

        public void AzuriranjeAnamneze(Anamneza staraAnamneza,String noviOpis,Pacijent pacijent)
        {
            azuriranjeAnamnezeService.AzuriranjeAnamneze(staraAnamneza,noviOpis,pacijent);
        }
    }
}

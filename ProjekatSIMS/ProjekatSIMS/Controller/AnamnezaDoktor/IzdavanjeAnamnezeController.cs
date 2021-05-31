using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    
    public class IzdavanjeAnamnezeController
    {
        private IzdavanjeAnamnezeService izdavanjeAnamnezeService = new IzdavanjeAnamnezeService();
        public void KreiranjeAnamneze(String opis,DateTime datumIzdavanja, Pacijent pacijent)
        {
            izdavanjeAnamnezeService.KreiranjeAnamneze(opis,datumIzdavanja,pacijent);
        }
    }
}

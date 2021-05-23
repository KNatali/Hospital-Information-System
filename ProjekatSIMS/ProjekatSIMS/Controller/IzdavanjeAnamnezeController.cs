using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller
{
    
    public class IzdavanjeAnamnezeController
    {
        private IzdavanjeAnamnezeService izdavanjeAnamnezeService = new IzdavanjeAnamnezeService();
        public void KreiranjeAnamneze(String opis,DateTime datumIzdavanja, ZdravsteniKarton karton)
        {
            izdavanjeAnamnezeService.KreiranjeAnamneze(opis,datumIzdavanja,karton);
        }
    }
}

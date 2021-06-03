using Model;
using ProjekatSIMS.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    
    public class IzdavanjeAnamnezeController
    {
        private IzdavanjeAnamnezeService izdavanjeAnamnezeService = new IzdavanjeAnamnezeService();
        public void KreiranjeAnamneze(AnamnezaDTO anamneza)
        {
            izdavanjeAnamnezeService.KreiranjeAnamneze(anamneza);
        }
    }
}

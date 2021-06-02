using Model;
using ProjekatSIMS.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class IzdavanjeReceptaController
    {
        private IzdavanjeReceptaService izdavanjeReceptaService = new IzdavanjeReceptaService();
        private AlergijeNaLijekService alergijeNaLijekService = new AlergijeNaLijekService();

        public void IzdavanjeRecepta(ReceptDTO receptDTO)
        {
            izdavanjeReceptaService.IzdavanjeRecepta(receptDTO);
            
        }

       
    }
}

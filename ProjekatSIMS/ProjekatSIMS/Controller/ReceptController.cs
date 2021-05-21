using Model;
using ProjekatSIMS.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    class ReceptController
    {
        private IzdavanjeReceptaService izdavanjeReceptaService = new IzdavanjeReceptaService();
        private AlergijeNaLijekService alergijeNaLijekService = new AlergijeNaLijekService();

        public void IzdavanjeRecepta(ReceptDTO receptDTO)
        {
            izdavanjeReceptaService.IzdavanjeRecepta(receptDTO);
            
        }

        public Boolean IsPacijentAlergican(Lijek izabraniLijek,Pacijent pacijent)
        {
            if(alergijeNaLijekService.IsPacijentAlergican(izabraniLijek,pacijent))
                 return true;
            return false;

        }
    }
}

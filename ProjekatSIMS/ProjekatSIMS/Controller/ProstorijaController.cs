using Model;
using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller
{
    
    public class ProstorijaController
    {
        public ProstorijaService prostorijaService = new ProstorijaService();



        public Boolean IzmeniProstoriju(String idProstorijeZaIzmenu, String vrsta, int sprat, double kvadratura)
        {
            Prostorija prostorijaZaIzmenu = prostorijaService.pronadjiProstorijuPoId(idProstorijeZaIzmenu);
            if(prostorijaService.daLiJeGlavniMagacin(idProstorijeZaIzmenu, vrsta))
            {
                return false;
            }
            prostorijaService.IzmenaProstorije(idProstorijeZaIzmenu, prostorijaService.kojaJeVrsta(vrsta), sprat, kvadratura);
            return true;

        }
        public bool KreirajProstoriju(String id, String vrsta, int sprat, double kvadratura)
        {
            if(prostorijaService.pronadjiProstorijuPoId(id) != null)
            {
                return false;
            }
            prostorijaService.KreiranjeProstorije(id, prostorijaService.kojaJeVrsta(vrsta), sprat, kvadratura);
            return true;
        }
    }
}

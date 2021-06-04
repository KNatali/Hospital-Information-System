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
            Prostorija prostorijaZaIzmenu = prostorijaService.PronadjiProstorijuPoId(idProstorijeZaIzmenu);
            if(prostorijaService.DaLiJeGlavniMagacin(idProstorijeZaIzmenu))
            {
                vrsta = VrstaProstorije.GlavniMagacin.ToString();
            }
            prostorijaService.IzmenaProstorije(idProstorijeZaIzmenu, prostorijaService.KojaJeVrsta(vrsta), sprat, kvadratura);
            return true;

        }
        public bool KreirajProstoriju(String id, String vrsta, int sprat, double kvadratura)
        {
            if(prostorijaService.PronadjiProstorijuPoId(id) != null)
            {
                return false;
            }
            prostorijaService.prostorijaRepository.KreirajProstoriju(id, prostorijaService.KojaJeVrsta(vrsta), sprat, kvadratura);
            return true;
        }
        public List<Prostorija> DobaviSve()
        {
            return prostorijaService.DobaviSve();
        }
    }
}

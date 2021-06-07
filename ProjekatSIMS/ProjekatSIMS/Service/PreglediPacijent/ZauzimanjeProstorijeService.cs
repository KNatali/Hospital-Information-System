using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.PreglediPacijent
{
    public class ZauzimanjeProstorijeService
    {
        public static ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        public List<Prostorija> prostorije = prostorijaRepository.DobaviSve();

       public  Prostorija prostorija = new Prostorija();

        public Prostorija ZauzmiProstoriju()
        {
            foreach (Prostorija pr in prostorije)
            {
                if (pr.slobodna == true)
                {
                    prostorija = pr;
                    pr.slobodna = false;
                    break;
                }
            }
            return prostorija;
        }
    }
}

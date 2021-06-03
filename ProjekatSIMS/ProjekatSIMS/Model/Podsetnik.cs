using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Model
{
    public class Podsetnik
    {
        public String nazivPodsetika { get; set; }
        public String opisPodsetnika { get; set; }
        public DateTime datumPocetkaObavestenja { get; set; }
        public DateTime datumZavrsetkaObavestenja { get; set; }

        public String pacijent { get; set; }
        public Podsetnik()
        {

        }
        public Podsetnik(String naziv, String opis, DateTime pocetak, DateTime kraj)
        {
            this.nazivPodsetika = naziv;
            this.opisPodsetnika = opis;
            this.datumPocetkaObavestenja = pocetak;
            this.datumZavrsetkaObavestenja = kraj;
        }

      

    }
}

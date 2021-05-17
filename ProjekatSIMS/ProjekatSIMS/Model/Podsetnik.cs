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

        public Pacijent pacijent { get; set; }
        public Podsetnik()
        {

        }

      

    }
}

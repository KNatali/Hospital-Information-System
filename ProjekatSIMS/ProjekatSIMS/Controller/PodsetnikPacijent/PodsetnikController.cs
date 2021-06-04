using System;
using System.Collections.Generic;
using System.Text;
using ProjekatSIMS.Service;
using Service;

namespace Controller
{
   public class PodsetnikController
    {
        public PrikazivanjePodsetnikaService prikazivanjePodsetnikaService = new PrikazivanjePodsetnikaService();
        public KreiranjePodsetnikaService kreiranjePodsetnikaService = new KreiranjePodsetnikaService();
        public Boolean KreiranjePodsetnika(String naziv, String opis, DateTime pocetakObavestenja, DateTime krajObavestenja, String imePacijenta, String prezimePacijenta)
        {
            if (kreiranjePodsetnikaService.kreiranjePodsetnika(naziv, opis, pocetakObavestenja, krajObavestenja, imePacijenta, prezimePacijenta) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean DaLiTrebaPoslatiObavestenje(DateTime pocetak, DateTime kraj)
        {
            if (prikazivanjePodsetnikaService.DaLiTrebaPoslatiObavestenje(pocetak, kraj) == true) {
                return true;
            }
            return false;
        }
    }
}

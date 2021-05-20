using System;
using System.Collections.Generic;
using System.Text;
using ProjekatSIMS.Service;
using Service;

namespace Controller
{
   public class PodsetnikController
    {
        public Podsetnikservice podsetnikservice = new Podsetnikservice();
        public Boolean KreiranjePodsetnika(String naziv, String opis, DateTime pocetakObavestenja, DateTime krajObavestenja, String imePacijenta, String prezimePacijenta)
        {
            if (podsetnikservice.kreiranjePodsetnika(naziv, opis, pocetakObavestenja, krajObavestenja, imePacijenta, prezimePacijenta) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}

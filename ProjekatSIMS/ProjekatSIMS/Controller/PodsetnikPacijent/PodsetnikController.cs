using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.Service;
using Service;

namespace Controller
{
   public class PodsetnikController
    {
        public PrikazivanjePodsetnikaService prikazivanjePodsetnikaService = new PrikazivanjePodsetnikaService();
        public KreiranjePodsetnikaService kreiranjePodsetnikaService = new KreiranjePodsetnikaService();
        public PodsetnikRepository podsetnikRepository = new PodsetnikRepository();
        public Boolean KreiranjePodsetnika(String naziv, String opis, DateTime pocetakObavestenja, DateTime krajObavestenja, String jmbgPacijenta)
        {
            if (kreiranjePodsetnikaService.kreiranjePodsetnika(naziv, opis, pocetakObavestenja, krajObavestenja, jmbgPacijenta) == true)
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

        public List<Podsetnik> DobaviSvePodsetnikeZaPacijenta(Pacijent pacijent)
        {
            return podsetnikRepository.DobaviSvePodsetnikeZaPacijenta(pacijent);
        }
    }
}

using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class PacijentController
    {
        public Service.PacijentService pacijentService = new PacijentService();
        public List<Pacijent> DobaviSve()
        {
            return pacijentService.DobaviSve();
        }
        public Boolean ProveraImePrezime(String ime, String prezime)
        {
            if (pacijentService.ProveraImePrezime(ime, prezime))
                return true;
            return false;
        }
    }
}

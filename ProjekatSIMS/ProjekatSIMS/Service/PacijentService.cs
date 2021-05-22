using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class PacijentService
    {
        public Repository.PacijentRepository pacijentRepository = new PacijentRepository();
        public List<Pacijent> DobaviSve()
        {
            return pacijentRepository.DobaviSve();
        }
        public Boolean ProveraImePrezime(String ime, String prezime)
        {
            List<Pacijent> pacijenti = pacijentRepository.DobaviSve();
            foreach(Pacijent p in pacijenti)
            {
                if (p.Ime == ime && p.Prezime == prezime)
                {
                    break;
                }
            }
            return true;
        }
    }
}

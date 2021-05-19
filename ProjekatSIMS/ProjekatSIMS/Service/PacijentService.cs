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
        /*private static Pacijent ProveraImePrezime()
        {
            
        }*/
    }
}

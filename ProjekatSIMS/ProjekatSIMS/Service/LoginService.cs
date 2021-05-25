using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class LoginService
    {
        public PacijentRepository pacijentRepository = new PacijentRepository();
        public Boolean DaLiJeKorisnikBlokiran(String jmbg)
        {
            List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();
            foreach(Pacijent p in Pacijenti)
            {
                if((p.Jmbg == jmbg) && (p.jesteMaliciozanKorisnik == true))
                {
                    return true;
                }
            }
            return false;

        }
    }
}

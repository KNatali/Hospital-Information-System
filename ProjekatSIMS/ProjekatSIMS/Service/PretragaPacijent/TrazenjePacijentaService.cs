using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.PretragaPacijent
{
    public class TrazenjePacijentaService
    {
        public static PacijentRepository pacijentRepository = new PacijentRepository();
        public Pacijent pacijent = new Pacijent();
        public List<Pacijent> pacijenti = pacijentRepository.DobaviSve();
        public Pacijent PronalazenjePacijenta(Pacijent pac)
        {
            foreach (Pacijent p in pacijenti)
            {
                if ((p.Jmbg == pac.Jmbg))
                {
                    pacijent = p;
                }
            }
            return pacijent;
        }

        public Boolean DaLiPostojiPacijent(Pacijent pac)
        {
            foreach (Pacijent p in pacijenti)
            {
                if ((p.Jmbg == pac.Jmbg))
                {
                    return true;
                }
            }
            return false;
        }
       
    }
}

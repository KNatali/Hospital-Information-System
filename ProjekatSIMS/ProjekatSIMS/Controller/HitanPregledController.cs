using System;
using Service;
using Model;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class HitanPregledController
    {
        public Service.HitanPregledService hpService = new HitanPregledService();
        public List<Pacijent> DobaviSvePacijente()
        {
            return hpService.DobaviSvePacijente();
        }
        public Boolean KreiranjeHitnogProfila(Pacijent pacijent)
        {
            if (hpService.KreiranjeHitnogProfila(pacijent) == true)
                return true;
            else
                return false;
        }
    }
}

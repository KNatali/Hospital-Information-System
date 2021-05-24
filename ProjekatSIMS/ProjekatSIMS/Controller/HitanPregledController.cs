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
        public Boolean ZakazivanjeKodDoktoraOpstePrakse(Pregled pregled, Pacijent pacijent)
        {
            if (hpService.ZakazivanjeKodDoktoraOpstePrakse(pregled, pacijent) == true)
                return true;
            else
                return false;
        }
        public Boolean ZakazivanjeKodDoktoraKardiologa(Pregled pregled, Pacijent pacijent)
        {
            if (hpService.ZakazivanjeKodDoktoraKardiologa(pregled, pacijent) == true)
                return true;
            else
                return false;
        }
        public Boolean ZakazivanjeKodDoktoraHirurga(Pregled pregled, Pacijent pacijent)
        {
            if (hpService.ZakazivanjeKodDoktoraHirurga(pregled, pacijent) == true)
                return true;
            else
                return false;
        }
    }
}

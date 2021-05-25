using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class PrikazivanjePodsetnikaService
    {
        public Boolean DaLiTrebaPoslatiObavestenje(DateTime krajObavestenja, DateTime pocetakObavestenja)
        {
            int porediKrajSaSadasnjim = DateTime.Compare(krajObavestenja, DateTime.UtcNow);
            int porediPocetakSaSadasnjim = DateTime.Compare(pocetakObavestenja, DateTime.UtcNow);
            if ((porediKrajSaSadasnjim >= 0) && (porediPocetakSaSadasnjim <= 0))
            {
                return true;
            }
            return false;
        }
    }
}

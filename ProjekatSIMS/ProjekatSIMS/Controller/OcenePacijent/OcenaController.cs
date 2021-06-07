using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller
{
   public class OcenaController
    {
        public OcenjivanjeBolniceService ocenjivanjeBolniceService = new OcenjivanjeBolniceService();
        public OcenjivanjeLekaraService ocenjivanjeLekaraService = new OcenjivanjeLekaraService();

        public Boolean ProsledjenaOcenaBolnice(String ocena, String komentar)
        {
            if(ocenjivanjeBolniceService.OcenjivanjeBolnice(ocena,komentar) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ProsledjenaOcenaLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            if (ocenjivanjeLekaraService.OcenjivanjeLekara(imeLekara, prezimeLekara, ocena, komentar) == true)
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

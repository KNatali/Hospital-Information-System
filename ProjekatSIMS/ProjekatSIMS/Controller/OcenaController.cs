using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller
{
   public class OcenaController
    {

        public Service.OcenaService ocenaService = new OcenaService();

        public Boolean ProsledjenaOcenaBolnice(String ocena, String komentar)
        {
            if(ocenaService.OcenjivanjeBolnice(ocena,komentar) == true)
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
            if (ocenaService.OcenjivanjeLekara(imeLekara, prezimeLekara, ocena, komentar) == true)
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

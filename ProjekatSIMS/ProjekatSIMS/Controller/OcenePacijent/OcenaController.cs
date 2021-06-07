using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
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
        public OcenaRepository ocenaRepository = new OcenaRepository();

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

        public List<OcenaBolnice> DobaviSveOceneBolnice()
        {
            return ocenaRepository.DobaviSveOceneBolnice();
        }

        public List<OcenaLekara> DobaviSveOceneLekara()
        {
            return ocenaRepository.DobaviSveOceneLekara();
        }
    }
}

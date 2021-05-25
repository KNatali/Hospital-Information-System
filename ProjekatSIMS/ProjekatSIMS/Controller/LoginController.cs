using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller
{
    public class LoginController
    {
        public LoginService loginService = new LoginService();

        public Boolean DaLiJeKorisnikBlokiran(String jmbg)
        {
            if(loginService.DaLiJeKorisnikBlokiran(jmbg) == true)
            {
                return true;
            }
            return false;
        }
    }
}

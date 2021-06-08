using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ProjekatSIMS.Model;
using Service;

namespace ProjekatSIMS.Controller
{
    public class KreiranjeProfila
    {
        public Service.KreiranjeProfila kreiranjeProfila = new Service.KreiranjeProfila();
        public Boolean KreirajProfil(Uloga uloga)
        {
            if (kreiranjeProfila.KreirajProfil(uloga) == true)
                return true;
            else
                return false;
        }
    }
}

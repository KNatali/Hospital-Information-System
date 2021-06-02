using System;
using System.Collections.Generic;
using System.Text;
using Service;
using Model;

namespace Controller
{
    public class AlergijeNaLijekController
    {
        private AlergijeNaLijekService alergijeNaLijekService = new AlergijeNaLijekService();

        public Boolean IsPacijentAlergican(Lijek izabraniLijek, Pacijent pacijent)
        {
            if (alergijeNaLijekService.IsPacijentAlergican(izabraniLijek, pacijent))
                return true;
            return false;

        }
    }
}

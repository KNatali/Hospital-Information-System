using System;
using System.Collections.Generic;
using System.Text;
using Service;
using Model;
using ProjekatSIMS.Service.UputDoktor;

namespace ProjekatSIMS.Controller.UputDoktor
{
    public class NadjiSlobodnuOrdinacijuController
    {

        public NadjiSlobodnuOrdinacijuService nadjiSlobodnuOrdinacijuService = new NadjiSlobodnuOrdinacijuService();

        public Prostorija NadjiSlobodnuOrdinaciju(DateTime terminPocetak)
        {
            return nadjiSlobodnuOrdinacijuService.NadjiSlobodnuOrdinaciju(terminPocetak);
        }
    }
}

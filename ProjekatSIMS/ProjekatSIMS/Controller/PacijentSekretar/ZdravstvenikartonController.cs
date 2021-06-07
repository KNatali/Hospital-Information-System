
using Service;
using System;
using Model;
using System.Collections.Generic;

namespace Controller
{
   public class ZdravstvenikartonController
   {
      public Service.ZdravstvenikartonService zdravstvenikartonService = new ZdravstvenikartonService();
        public void kreiranjeAlergena(String alergen, Pacijent p)
        {
            zdravstvenikartonService.kreiranjeAlergena(alergen, p);
        }
        public List<String> DobaviSveAlergene(Pacijent pacijent)
        {
            return zdravstvenikartonService.DobaviSveAlergene(pacijent);
        }
    }
}
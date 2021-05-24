using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public class DoktorController
    {
        public Service.DoktorService doktorService = new DoktorService();
        public List<Doktor> DobaviSve()
        {
            return doktorService.DobaviSve();
        }
        public Boolean kreiranjeProfila(Doktor doktor)
        {
            if (doktorService.kreiranjeProfila(doktor) == true)
                return true;
            else
                return false;
        }
        public Boolean cuvanjeIzmenjenjihPodataka(Doktor stariPodaci)
        {
            if (doktorService.cuvanjeIzmenjenjihPodataka(stariPodaci))
                return true;
            else
                return false;
        }
    }
}

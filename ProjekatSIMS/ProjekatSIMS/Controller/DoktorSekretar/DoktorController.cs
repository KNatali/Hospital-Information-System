using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Repository;

namespace Controller
{
    public class DoktorController
    {
        public Service.DoktorService doktorService = new DoktorService();

        public List<Doktor> DobaviSve()
        {
            return doktorService.DobaviSve();
        }
        public Boolean KreiranjeProfila(Doktor doktor)
        {
            if (doktorService.KreiranjeProfila(doktor) == true)
                return true;
            else
                return false;
        }
        public Boolean CuvanjeIzmenjenjihPodataka(Doktor stariPodaci)
        {
            if (doktorService.CuvanjeIzmenjenjihPodataka(stariPodaci))
                return true;
            else
                return false;
        }
        public Boolean ObrisiDoktora(Doktor stariDoktor)
        {
            if (doktorService.ObrisiDoktora(stariDoktor))
                return true;
            else
                return false;
        }
    }
}

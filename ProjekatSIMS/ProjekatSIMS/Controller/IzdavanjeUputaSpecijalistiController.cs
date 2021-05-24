using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class IzdavanjeUputaSpecijalistiController
    {

        private IzdavanjeUputaSpecijalistiService izdavanjeUputaSpecijalistiService = new IzdavanjeUputaSpecijalistiService();
   
        public Boolean IzdavanjeUputa(Pacijent pacijent, Doktor doktor, DateTime izabraniTermin)
        {
            if (izdavanjeUputaSpecijalistiService.IzdavanjeUputa(pacijent, doktor, izabraniTermin))
                return true;
            return false;
        }
    }
}

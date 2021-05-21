using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    class ProduzenjeUputaBolnickoLijecenjeController
    {
        private ProduzenjeUputaBolnickoLijecenjeService uputService = new ProduzenjeUputaBolnickoLijecenjeService();

        public bool IsProduzavanjeMoguce(UputBolnickoLijecenje uput, DateTime krajIntervala)
        {
            return uputService.IsProduzavanjeMoguce(uput, krajIntervala);
        }

        public void ProduzavanjeUputa(UputBolnickoLijecenje uput, DateTime krajIntervala, Pacijent pacijent)
        {
            uputService.ProduzavanjeUputa(uput, krajIntervala, pacijent);
        }
    }
}

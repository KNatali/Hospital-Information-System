using Model;
using ProjekatSIMS.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class IzdavanjeUputaBolnickoLijecenjeController
    {
        private IzdavanjeUputaBolnickoLijecenjeService uputService = new IzdavanjeUputaBolnickoLijecenjeService();
        public List<SlobodniKrevetDTO> DobaviSlobodneSobe(DateTime pocetakIntervala,DateTime krajIntervala)
        {
          
            return uputService.DobaviSlobodneSobe(pocetakIntervala,krajIntervala);
        }

        public void CuvanjeUputa(UputBolnickoLijecenje uput,Pacijent pacijent)
        {
            uputService.CuvanjeUputa(uput, pacijent);
        }
        
    }
}

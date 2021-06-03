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

        private IzdavanjeUputaBolnickoLijecenjeService izdavanjeUPutaBolnickoLijecenjeService = new IzdavanjeUputaBolnickoLijecenjeService();
        public void  CuvanjeUputa(UputBolnickoLijecenjeDTO uput,Pacijent pacijent)
        {
            izdavanjeUPutaBolnickoLijecenjeService.CuvanjeUputa(uput,pacijent);
        }
    }
}

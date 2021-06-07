using Model;
using ProjekatSIMS.Service.PreglediPacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.PregledPacijent
{
    public class BrojacOtkazivanjaController
    {
        
        
        public BrojacOtkazivanjaService brojacOtkazivanjaService = new BrojacOtkazivanjaService();

       
        public void BrojacOtkazivanjaPregleda(Pacijent pacijent)
        {
            brojacOtkazivanjaService.BrojacOtkazivanjaPregleda(pacijent);
        }
    }
}

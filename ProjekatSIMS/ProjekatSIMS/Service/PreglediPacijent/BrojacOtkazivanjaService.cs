using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.PreglediPacijent
{
   public  class BrojacOtkazivanjaService
    {
        public static PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        public List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();
        public void BrojacOtkazivanjaPregleda(Pacijent pacijent)
        {
                    pacijent.otkazaoPregled++;
        }
    }
}

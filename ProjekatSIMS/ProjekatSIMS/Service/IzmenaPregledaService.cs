using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class IzmenaPregledaService
    {
        public static PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        public List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();

        public void BrojacOtkazivanjaPregleda(String ime, String prezime)
        {
            foreach (Pacijent pac in Pacijenti)
            {
                if ((pac.Prezime == prezime) && (pac.Ime == ime))
                {
                    pac.otkazaoPregled++;
                }
            }
        }
    }
}

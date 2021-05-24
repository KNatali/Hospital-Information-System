using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class OcenjivanjeBolniceService
    {
        public OcenaRepository ocenaRepositoryBolnica = new OcenaRepository(@"..\..\..\Fajlovi\OcenaBolnice.txt");
        public PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
        public bool bolnicaSeMozeOceniti = false;
        private Boolean DaLiSeBolnicaMozeOceniti()
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if (p.StatusPregleda == StatusPregleda.Zavrsen)
                {
                    return true;

                }
            }
            return false;
        }

        private OcenaBolnice PostavljanjeOceneBolnice(String ocena, String komentar)
        {
            OcenaBolnice ob = new OcenaBolnice { Ocena = ocena, Komentar = komentar };
            return ob;
        }

        public Boolean OcenjivanjeBolnice(String ocena, String komentar)
        {
            if (DaLiSeBolnicaMozeOceniti() == true)
            {
                List<OcenaBolnice> oceneBolnice = ocenaRepositoryBolnica.DobaviSveOceneBolnice();
                oceneBolnice.Add(PostavljanjeOceneBolnice(ocena, komentar));
                ocenaRepositoryBolnica.SacuvajOcenuBolnice(oceneBolnice);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

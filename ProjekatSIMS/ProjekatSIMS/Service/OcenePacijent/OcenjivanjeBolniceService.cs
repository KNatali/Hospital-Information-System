using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.Service.OcenePacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class OcenjivanjeBolniceService
    {
        public OcenaRepository ocenaRepositoryBolnica = new OcenaRepository(@"..\..\..\Fajlovi\OcenaBolnice.txt");
        public TrazenjeZavrsenogPregledaService trazenjeZavrsenogPregleda = new TrazenjeZavrsenogPregledaService();
       
        private OcenaBolnice PostavljanjeOceneBolnice(String ocena, String komentar)
        {
            OcenaBolnice ob = new OcenaBolnice { Ocena = ocena, Komentar = komentar };
            return ob;
        }

        public Boolean OcenjivanjeBolnice(String ocena, String komentar)
        {
            if (trazenjeZavrsenogPregleda.DaLiPostojiZavrsenPregled() == true)
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

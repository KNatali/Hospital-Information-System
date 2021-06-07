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
    public class OcenjivanjeLekaraService
    {
        public OcenaRepository ocenaRepositoryLekar = new OcenaRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
        public PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
        public TrazenjeZavrsenogPregledaService trazenjeZavrsenogPregleda = new TrazenjeZavrsenogPregledaService();
        public TrazenjeLekaraService trazenjeLekara = new TrazenjeLekaraService();
        
        private OcenaLekara PostavljanjeOceneLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            OcenaLekara ol = new OcenaLekara { ImeLekara = imeLekara, PrezimeLekara = prezimeLekara, Ocena = ocena, Komentar = komentar };
            return ol;
        }

    

        public Boolean OcenjivanjeLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            List<OcenaLekara> oceneLekara = ocenaRepositoryLekar.DobaviSveOceneLekara();
            if (ocena != null)
            {
                if ((trazenjeLekara.DaLiPostojiLekar(imeLekara, prezimeLekara) == true) && (trazenjeZavrsenogPregleda.DaLiPostojiZavrsenPregled() == true))
                {
                    oceneLekara.Add(PostavljanjeOceneLekara(imeLekara, prezimeLekara, ocena, komentar));
                    ocenaRepositoryLekar.SacuvajOcenuLekara(oceneLekara);
                    return true;

                }
                return false;
            }
            else
            {
                return false;
            }
        }
       
    }
}

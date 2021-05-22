using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class OcenaService
    {

        public Repository.OcenaRepository ocenaRepositoryLekar = new OcenaRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
        public OcenaRepository ocenaRepositoryBolnica = new OcenaRepository(@"..\..\..\Fajlovi\OcenaBolnice.txt");
        public PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
       
        public bool lekarSeMozeOceniti = false;
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
            OcenaBolnice ob = new OcenaBolnice();
            ob.Ocena = ocena;
            ob.Komentar = komentar;
            return ob;
        }

        public Boolean OcenjivanjeBolnice(String ocena, String komentar)
        {
            if( DaLiSeBolnicaMozeOceniti() == true)
            {
                List<OcenaBolnice> oceneBolnice = ocenaRepositoryBolnica.DobaviSveOceneBolnice();
                oceneBolnice.Add(PostavljanjeOceneBolnice(ocena,komentar));
                ocenaRepositoryBolnica.SacuvajOcenuBolnice(oceneBolnice);
                return true;
            }else
            {
                return false;
            }
           
        }

        private Boolean DaLiSeLekarMozeOceniti(String ime,String prezime)
        {
            bool mozeSeOceniti = false;
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if((p.doktor.Ime == ime) && (p.doktor.Prezime == prezime))
                {
                    mozeSeOceniti = true;
                    break;
                }
            }
            return mozeSeOceniti;
            
        }

        private OcenaLekara PostavljanjeOceneLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            OcenaLekara ol = new OcenaLekara();
            ol.ImeLekara = imeLekara;
            ol.PrezimeLekara = prezimeLekara;
            ol.Ocena = ocena;
            ol.Komentar = komentar;

            return ol;
        }

        private Boolean DaLiPostojiZavrsenPregled()
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if ((p.StatusPregleda == StatusPregleda.Zavrsen))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean OcenjivanjeLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            List<OcenaLekara> oceneLekara = ocenaRepositoryLekar.DobaviSveOceneLekara();
            if(ocena != null) 
            {
                if ((DaLiSeLekarMozeOceniti(imeLekara,prezimeLekara) == true)  && (DaLiPostojiZavrsenPregled()== true))
                {
                    oceneLekara.Add(PostavljanjeOceneLekara(imeLekara,prezimeLekara,ocena,komentar));
                    ocenaRepositoryLekar.SacuvajOcenuLekara(oceneLekara);
                    return true;
                   
                }
                return false ;
            }else
            {
                return false;
            }
        }
    }
}

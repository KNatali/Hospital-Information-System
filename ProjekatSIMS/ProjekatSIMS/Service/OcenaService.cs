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

        public Repository.OcenaRepository ocenaRepository = new OcenaRepository();
       
        public bool lekarSeMozeOceniti = false;
        

       

        public Boolean OcenjivanjeBolnice(String ocena, String komentar)
        {
            if( ocena != null)
            {
                OcenaBolnice ob = new OcenaBolnice();
                ocenaRepository = new OcenaRepository(@"..\..\..\Fajlovi\OcenaBolnice.txt");
                List<OcenaBolnice> oceneBolnice = ocenaRepository.DobaviSveOceneBolnice();
                ob.Ocena = ocena;
                ob.Komentar = komentar;
                oceneBolnice.Add(ob);
                ocenaRepository.SacuvajOcenuBolnice(oceneBolnice);
                return true;
            }
            else
            {
                return false;
            }
           
        }

        private Boolean DaLiSeLekarMozeOceniti(String ime,String prezime)
        {
            bool mozeSeOceniti = false;
            PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
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

        public Boolean OcenjivanjeLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            OcenaLekara ol = new OcenaLekara();
            List<Pregled> pregledi = new List<Pregled>();
            ocenaRepository = new OcenaRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
            List<OcenaLekara> oceneLekara = ocenaRepository.DobaviSveOceneLekara();
            PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if ((p.StatusPregleda == StatusPregleda.Zavrsen) && (DaLiSeLekarMozeOceniti(imeLekara,prezimeLekara) == true))
                {
                    return true;
                    
                }
            }
            if(ocena != null) 
            {
                if (DaLiSeLekarMozeOceniti(imeLekara,prezimeLekara) == true)
                {
                    ol.ImeLekara = imeLekara;
                    ol.PrezimeLekara = prezimeLekara;
                    ol.Ocena = ocena;
                    ol.Komentar = komentar;
                    oceneLekara.Add(ol);
                    ocenaRepository.SacuvajOcenuLekara(oceneLekara);
                    return true;
                   
                }
                return false ;
            }
            else
            {
                return false;
            }
           



           
        }
    }
}

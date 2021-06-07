using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace ProjekatSIMS.Repository
{
    public class IstorijaLogovanjaRepository
    {
        private const String putanja = @"..\..\..\Fajlovi\IstorijaLogovanja.txt";

        public List<RegistrovaniKorisnik> DobaviSve()
        {
            List<RegistrovaniKorisnik> logovanja = new List<RegistrovaniKorisnik>();
            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                logovanja = JsonConvert.DeserializeObject<List<RegistrovaniKorisnik>>(json);
            }
            return logovanja;
        }

        public Boolean IsLogovan(RegistrovaniKorisnik korisnik)
        {
            List<RegistrovaniKorisnik> logovanja = DobaviSve();
            List<RegistrovaniKorisnik> nova;
            if (logovanja == null)
            {
                nova = new List<RegistrovaniKorisnik>();
                nova.Add(korisnik);
                SacuvajSve(nova);
                return false;
            }
            nova = logovanja;

            int br = 0;
            foreach(RegistrovaniKorisnik r in logovanja)
            {
                
                if (r.KorisnickoIme == korisnik.KorisnickoIme && r.Lozinka == korisnik.Lozinka)
                {
                  
                    br++;
                    break;
                   
                }
                    
            }
            if (br == 0)
            {
                nova.Add(korisnik);
                SacuvajSve(nova);
                return false;
            }
           
            return true;


        }

        public void SacuvajSve(List<RegistrovaniKorisnik> korisnici)
        {
            string newJson = JsonConvert.SerializeObject(korisnici);
            File.WriteAllText(putanja, newJson);
        }
    }
}

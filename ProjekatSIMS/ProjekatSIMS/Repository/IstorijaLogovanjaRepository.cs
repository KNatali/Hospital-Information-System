using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            foreach(RegistrovaniKorisnik r in logovanja)
            {
                if (!(r.KorisnickoIme == korisnik.KorisnickoIme && r.Lozinka == korisnik.Lozinka))
                {
                    nova.Add(korisnik);
                    SacuvajSve(nova);
                    return false;
                }
                    
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

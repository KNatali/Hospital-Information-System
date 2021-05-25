using Newtonsoft.Json;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
   public class OcenaRepository
    {
        private String lokacijaBolnica = @"..\..\..\Fajlovi\OcenaBolnice.txt";
        private String lokacijaLekar = @"..\..\..\Fajlovi\OcenaLekara.txt";
        private String lokacija;
        private List<OcenaLekara> oceneLekara;
        private List<OcenaBolnice> oceneBolnice;

        public OcenaRepository(String l)
        {
            lokacija = l;
        }

        public OcenaRepository()
        {
        }

        public void SacuvajOcenuBolnice(List<OcenaBolnice> ob)
        {
            string newJson = JsonConvert.SerializeObject(ob);
            File.WriteAllText(lokacija, newJson);
        }

        public List<OcenaBolnice> DobaviSveOceneBolnice()
        {
            using (StreamReader sr = new StreamReader(lokacijaBolnica))
            {
                string json = sr.ReadToEnd();

                oceneBolnice = JsonConvert.DeserializeObject<List<OcenaBolnice>>(json);
            }
            return oceneBolnice;
        }

        public void SacuvajOcenuLekara(List<OcenaLekara> ol)
        {
            string newJson = JsonConvert.SerializeObject(ol);
            File.WriteAllText(lokacija, newJson);
        }

        public List<OcenaLekara> DobaviSveOceneLekara()
        {
            using (StreamReader sr = new StreamReader(lokacijaLekar))
            {
                string json = sr.ReadToEnd();

                oceneLekara = JsonConvert.DeserializeObject<List<OcenaLekara>>(json);
            }
            return oceneLekara;
        }
    }
}

using Newtonsoft.Json;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
   public class OcenaBolniceRepository
    {
        private String lokacija;
        private List<OcenaBolnice> oceneBolnice;

        public OcenaBolniceRepository(String l)
        {
            lokacija = l;
        }

        public void SacuvajOcenuBolnice(List<OcenaBolnice> ob)
        {
            string newJson = JsonConvert.SerializeObject(ob);
            File.WriteAllText(lokacija, newJson);
        }

        public List<OcenaBolnice> DobaviSveOceneBolnice()
        {
            using (StreamReader sr = new StreamReader(lokacija))
            {
                string json = sr.ReadToEnd();

                oceneBolnice = JsonConvert.DeserializeObject<List<OcenaBolnice>>(json);
            }
            return oceneBolnice;
        }
    }
}

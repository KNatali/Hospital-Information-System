using Newtonsoft.Json;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
    public class OcenaLekaraRepository
    {
        private String lokacija;
        private List<OcenaLekara> oceneLekara;

        public OcenaLekaraRepository(String l)
        {
            lokacija = l;
        }

        public void SacuvajOcenuLekara(List<OcenaLekara> ol)
        {
            string newJson = JsonConvert.SerializeObject(ol);
            File.WriteAllText(lokacija, newJson);
        }

        public List<OcenaLekara> DobaviSveOceneLekara()
        {
            using (StreamReader sr = new StreamReader(lokacija))
            {
                string json = sr.ReadToEnd();

                oceneLekara = JsonConvert.DeserializeObject<List<OcenaLekara>>(json);
            }
            return oceneLekara;
        }
    }
}

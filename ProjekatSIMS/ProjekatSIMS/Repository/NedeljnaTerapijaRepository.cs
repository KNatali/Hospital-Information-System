using Newtonsoft.Json;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
    public class NedeljnaTerapijaRepository
    {
        private const string putanja = @"..\..\..\Fajlovi\NedeljnaTerapija.txt";

        public List<NedeljnaTerapija> DobaviSve()
        {

            List<NedeljnaTerapija> terapije = new List<NedeljnaTerapija>();
            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                terapije = JsonConvert.DeserializeObject<List<NedeljnaTerapija>>(json);
            }

            return terapije;
        }
    }
}

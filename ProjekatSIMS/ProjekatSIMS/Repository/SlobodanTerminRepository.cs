using Newtonsoft.Json;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
    class SlobodanTerminRepository

    {
        private String LokacijaFajla;
        private List<SlobodanTermin> termini;

        public SlobodanTerminRepository(String lokacija)
        {
            LokacijaFajla = lokacija;
        }
        public List<SlobodanTermin> DobaviSveSlobodneTermine()
        {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();
                termini = JsonConvert.DeserializeObject<List<SlobodanTermin>>(json);
            }
            return termini;
        }

        public void SacuvajSlobodanTermin(List<SlobodanTermin> termini)
        {
            string newJson = JsonConvert.SerializeObject(termini);
            File.WriteAllText(LokacijaFajla, newJson);

        }
    }
}

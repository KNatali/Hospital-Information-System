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
        private List<SlobodanTermin> terminiTmp;
        private SlobodanTermin st = new SlobodanTermin();
        private int terminiFlag = 0;

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

        public List<SlobodanTermin> DobaviSveSlobodneTermineZaDatum(DateTime datum)
        {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();
                termini = JsonConvert.DeserializeObject<List<SlobodanTermin>>(json);
                terminiTmp = JsonConvert.DeserializeObject<List<SlobodanTermin>>(json);


                foreach (SlobodanTermin t in termini)
                {
                    if (t.Termin.Date == datum.Date)
                    {
                        terminiTmp.Clear();
                        terminiTmp.Add(t);
                        st = t;
                        terminiFlag = 1;
                    }
                }
            }
            termini.Remove(st);
            if (terminiFlag == 1)
            {
                return terminiTmp;
            }
            else
            {
                terminiTmp.Clear();
                return terminiTmp;
            }
        }

        public List<SlobodanTermin> DobaviSveSlobodneTermineZaDoktora(String imeDoktora, String prezimeDoktora)
        {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();
                termini = JsonConvert.DeserializeObject<List<SlobodanTermin>>(json);
                terminiTmp = JsonConvert.DeserializeObject<List<SlobodanTermin>>(json);



                foreach (SlobodanTermin t in termini)
                {
                    if ((t.PrezimeDoktora == prezimeDoktora) && (t.ImeDoktora == imeDoktora))
                    {
                        terminiTmp.Clear();
                        terminiTmp.Add(t);
                        terminiFlag = 1;
                        st = t;
                    }
                }
                
            }
            
            termini.Remove(st);
            if (terminiFlag == 1)
            {
                return terminiTmp;
            }
            else
            {
                terminiTmp.Clear();
                return terminiTmp;
            }
            
        }
    }
}

using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
   public class ReceptRepository
   {
        private String LokacijaFajla;
        private List<Recept> recepti;

        public ReceptRepository(String lokacija)
        {
            LokacijaFajla = lokacija;
        }
        public void SacuvajRecept(List<Recept> recepti)
      {
            string newJson = JsonConvert.SerializeObject(recepti);
            File.WriteAllText(LokacijaFajla, newJson);
        }
      
      public List<Recept> DobaviSveRecepte()
      {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();
                recepti = JsonConvert.DeserializeObject<List<Recept>>(json);
            }
            return recepti;
        }
   
   }
}
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
        private List<Recept> recepti = new List<Recept>();

        public ReceptRepository(String lokacija)
        {
            LokacijaFajla = lokacija;
        }
        public ReceptRepository()
        {
            LokacijaFajla = @"..\..\..\Fajlovi\Recept.txt";
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

        public List<Recept> DobaviRecepteZaKarton(int id)
        {
            List<Recept> recepti = new List<Recept>();
            List<Recept>  sviRecepti = DobaviSveRecepte();
            foreach(Recept r in sviRecepti)
            {
                if (r.IdKartona == id)
                    recepti.Add(r);
            }
            return recepti;
        }

        public void DodajRecept(Recept recept)
        {
            recepti = DobaviSveRecepte();
            recepti.Add(recept);
            SacuvajRecept(recepti);
            
        }
   
   }
}
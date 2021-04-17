

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
   public class CuvanjeProstorija
   {
       // public Osoba[] osoba;

        private String lokacijaFajla;
        private List<Prostorija> prostorije;

        public CuvanjeProstorija(String lokacija)
        {
            this.lokacijaFajla = lokacija;
        }

      
      
      public void Sacuvaj(String prostorija, Boolean znak)
      {
            string json = JsonConvert.SerializeObject(prostorije);
            File.WriteAllText(lokacijaFajla, json);
      }
      
      public List<Prostorija> UcitajProstorije()
      {
         using(StreamReader r = new StreamReader(lokacijaFajla))
            {
                string json = r.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);

            }
            return prostorije;
      }
   
      
   }
}
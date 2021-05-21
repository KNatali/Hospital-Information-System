using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
   public class NotifikacijaRepository
   {
        private String lokacija = @"..\..\..\Fajlovi\Vesti.txt";
        private List<Notifikacija> n;
        public NotifikacijaRepository()
        {

        }
        public NotifikacijaRepository(String l)
        {
            lokacija = l;
        }
      public List<Notifikacija> DobaviSve()
      {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                n = JsonConvert.DeserializeObject<List<Notifikacija>>(json);
            }
            return n;
      }
      
      public void Sacuvaj(List<Notifikacija> notifikacija)
      {
            string newJson = JsonConvert.SerializeObject(notifikacija);
            File.WriteAllText(lokacija, newJson);
      }
    }
}
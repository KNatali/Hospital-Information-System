using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
   public class OsobaRepository
   {
        private String lokacija;
        private List<Pacijent> pacijenti;
        public OsobaRepository(String l)
        {
            lokacija = l;
        }
        public void Sacuvaj(List<Pacijent> p)
        {
            string newJson = JsonConvert.SerializeObject(p);
            File.WriteAllText(lokacija, newJson);
        }
        public List<Pacijent> DobaviPacijente()
        {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            return pacijenti;
        }
        public Model.Pacijent SacuvajHitniNalogRepository(String jmbg, String ime, String prezime)
      {
         //TODO
         return null;
      }

    }
}
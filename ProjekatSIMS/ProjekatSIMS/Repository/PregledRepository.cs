using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
   public class PregledRepository
   {
        private String lokacija;
        private List<ZdravsteniKarton> zk;
        public PregledRepository(String l)
        {
            lokacija = l;
        }
        public void SacuvajAlergen(List<ZdravsteniKarton> karton)
        {
            string newJson = JsonConvert.SerializeObject(karton);
            File.WriteAllText(lokacija, newJson);
        }
        public List<ZdravsteniKarton> DobaviAlergene()
        {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                zk = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            return zk;
        }
        public Model.Pregled SacuvajGuestPregledRepository(DateTime datumPregleda, Model.Pacijent pacijent)
      {
         // TODO: implement
         return null;
      }
      
      public List<Pregled> GetListaPregledaRepository(DateTime zaDan)
      {
         // TODO: implement
         return null;
      }
      
      public List<Pregled> GetListaPregledaRepository(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Pregled GetDatumRepository(DateTime datum)
      {
         // TODO: implement
         return null;
      }
      
      public List<Pregled> DobaviSvePregledePacijent()
      {
         // TODO: implement
         return null;
      }
      
      public void SacuvajPregledPacijent(List<Pregled> pregledi)
      {
         // TODO: implement
      }
      
      public List<Pregled> DobaviSvePregledeDoktor()
      {
         // TODO: implement
         return null;
      }
      
      public void SacuvajPregledDoktor()
      {
         // TODO: implement
      }
   
   }
}
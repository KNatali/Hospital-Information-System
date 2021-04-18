using Model;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Repository
{
   public class PregledRepository
   {
        private String lokacija;
        private List<Pregled> pregledi;
        public PregledRepository(String l)
        {
            lokacija = l;
        }
        public void SacuvajPregledSekretar(List<Pregled> p)
        {
            string newJson = JsonConvert.SerializeObject(p);
            File.WriteAllText(lokacija, newJson);
        }
        public List<Pregled> GetListaPregledaSekretar()
        {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            return pregledi;
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
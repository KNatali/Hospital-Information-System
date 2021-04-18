using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
   public class PregledRepository
   {
        private const string putanja = @"..\..\Fajlovi\Pregled.txt";
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
            List < Pregled > pregledi=new List<Pregled>();
            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            return pregledi;
        }
      
      public void SacuvajPregledDoktor(List<Pregled> pregledi)
      {

            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(putanja, newJson);
        }
   
   }
}
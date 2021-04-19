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
        private List<Pregled> pregledi;
        private String LokacijaFajla;
        
        private const string putanja = @"..\..\..\Fajlovi\Pregled.txt";
       
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




   
        

        public PregledRepository()
        {
            
        }
        

      

        public List<Pregled> DobaviSvePregledePacijent()
        {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();

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


        public void SacuvajPregledPacijent(List<Pregled> pregledi)
        {
            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(LokacijaFajla, newJson);

        }

    

      
      public void SacuvajPregledDoktor(List<Pregled> pregledi)
      {

            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(putanja, newJson);
        }
   
}

}
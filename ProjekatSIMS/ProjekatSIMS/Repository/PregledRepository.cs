using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
   public class PregledRepository
   {
        private String lokacija = @"..\..\..\Fajlovi\Pregled.txt";

        private List<ZdravsteniKarton> zk;

        private List<Pregled> pregledi;

      
        private const string putanja = @"..\..\..\Fajlovi\Pregled.txt";
       

        public PregledRepository(String l)
        {
            lokacija = l;
        }

        public void SacuvajAlergen(List<ZdravsteniKarton> karton)
        {
            string newJson = JsonConvert.SerializeObject(karton);
            File.WriteAllText(lokacija, newJson);
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
     public List<ZdravsteniKarton> DobaviAlergene()

        {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                zk = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            return zk;
        }




   
        

        public PregledRepository()
        {
            
        }

        public List<Pregled> DobaviSvePregledePacijent()
        {
            using (StreamReader sr = new StreamReader(lokacija))
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

        public List<Pregled> DobaviZakazanePreglede()
        {
            List<Pregled> sviPregledi = DobaviSvePregledeDoktor();
            List<Pregled> zakazaniPregledi = new List<Pregled>();
            foreach (Pregled p in sviPregledi)
            {
                if (p.StatusPregleda == StatusPregleda.Zakazan)
                    zakazaniPregledi.Add(p);

            }
            return zakazaniPregledi;
        }


        public void SacuvajPregledPacijent(List<Pregled> pregledi)
        {
            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(lokacija, newJson);

        }

    

      
      public void SacuvajPregledDoktor(List<Pregled> pregledi)
      {

            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(putanja, newJson);
        }
   
}

}
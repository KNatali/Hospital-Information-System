using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
   public class PregledRepository
   {
        private String lokacija = @"..\..\..\Fajlovi\Pregled.txt";

        private List<ZdravsteniKarton> zk;

        private List<Pregled> pregledi;
        private ObservableCollection<Pregled> preglediOC;

      
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
        public ObservableCollection<Pregled> DobaviSvePregledePacijentOC()
        {
            using (StreamReader sr = new StreamReader(lokacija))
            {
                string json = sr.ReadToEnd();

                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            return preglediOC;
        }
        public List<Pregled> DobaviPregledeZaPacijenta(Pacijent pacijent)
        {
            List<Pregled> pregledi = DobaviSvePregledePacijent();
            List<Pregled> preglediZaPacijenta = new List<Pregled>();
            foreach(Pregled p in pregledi)
            {
                if(p.pacijent.Jmbg == pacijent.Jmbg)
                {
                    preglediZaPacijenta.Add(p);
                }
            }
            return preglediZaPacijenta; 
        }

       public ObservableCollection<Pregled> DobaviPregledeZaPacijentaOC(Pacijent pacijent)
        {
            ObservableCollection<Pregled> pregledi = DobaviSvePregledePacijentOC();
            ObservableCollection<Pregled> preglediZaPacijenta = new ObservableCollection<Pregled>();
            foreach (Pregled p in pregledi)
            {
                if (p.pacijent.Jmbg == pacijent.Jmbg)
                {
                    preglediZaPacijenta.Add(p);
                }
            }
            return preglediZaPacijenta;
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

        public List<Pregled> DobaviZavrsenePreglede()
        {
            List<Pregled> sviPregledi = DobaviSvePregledeDoktor();
            List<Pregled> zavrseniPregledi = new List<Pregled>();
            foreach (Pregled p in sviPregledi)
            {
                if (p.StatusPregleda == StatusPregleda.Zavrsen)
                    zavrseniPregledi.Add(p);

            }
            return zavrseniPregledi;
        }

        public List<Pregled> DobaviZakazanePregledeDoktora(Doktor doktor)
        {

            List<Pregled> zakazaniPregledi =DobaviZakazanePreglede();
            List<Pregled> zakazaniPreglediDoktora = new List<Pregled>();
            foreach (Pregled p in zakazaniPregledi)
            {
                if (p.doktor.Jmbg == doktor.Jmbg)
                    zakazaniPreglediDoktora.Add(p);
            }
            return zakazaniPreglediDoktora;

        }

        public List<Pregled> DobaviZavrsenePregledeDoktora(Doktor doktor)
        {

            List<Pregled> zavrseniPregledi = DobaviZavrsenePreglede();
            List<Pregled> zavrseniPreglediDoktora = new List<Pregled>();
            foreach (Pregled p in zavrseniPregledi)
            {
                if (p.doktor.Jmbg == doktor.Jmbg)
                    zavrseniPreglediDoktora.Add(p);
            }
            return zavrseniPreglediDoktora;

        }

        public Pregled DobaviPregledById(int id)
        {
            List<Pregled> sviPregledi = DobaviSvePregledeDoktor();
            foreach (Pregled p in sviPregledi)
            {
                if (p.Id == id)
                    return p;
            }

            return null;
        }

        public void SacuvajPregledPacijent(List<Pregled> pregledi)
        {
            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(lokacija, newJson);

        }

    

      
      public void SacuvajPregledeDoktor(List<Pregled> pregledi)
      {

            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(putanja, newJson);
      }

      public void SacuvajPregledDoktor(Pregled pregled)
        {
            List<Pregled> sviPregledi = DobaviSvePregledeDoktor();
            if (sviPregledi.Count == 0)
            {
                pregled.Id = 1;
            }
            else
            {
                pregled.Id = sviPregledi[sviPregledi.Count - 1].Id + 1;
            }
            sviPregledi.Add(pregled);
            SacuvajPregledeDoktor(sviPregledi);
        }

       
}

}
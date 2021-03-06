using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{

    public class ProstorijaRepository
    {

        private const String putanja = @"..\..\..\Fajlovi\Prostorija.txt";



        public ProstorijaRepository(string v)
        {
            
        }

        public ProstorijaRepository()
        {
        }

        public List<Prostorija> DobaviSve()
        {
            List<Prostorija> prostorije = new List<Prostorija>();
            using (StreamReader sr = new StreamReader(putanja))
            {
                string json = sr.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);
            }
            return prostorije;
        }


        public void Sacuvaj(List<Prostorija> prostorije)
        {
            string json = JsonConvert.SerializeObject(prostorije);
            File.WriteAllText(putanja, json);
        }
        

        public Boolean Obrisi(String idProstorijeZaBrisanje)
        {
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = DobaviSve();
            foreach (Prostorija p in prostorije)
            {
                if (p.id == idProstorijeZaBrisanje)
                {
                    prostorije.Remove(p);
                    
                    Sacuvaj(prostorije);
                    return true;
                }
            }
            return false;
        }

        public Prostorija Pronadji(String Id)
        {
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = DobaviSve();

            foreach(Prostorija p in prostorije)
            {
                if(p.id == Id)
                {
                    return p;
                }
            }
            return null;

        }
        public List<Prostorija> DobaviPoVrsti(VrstaProstorije vrsta)
        {
            List<Prostorija> sveProstorije = DobaviSve();
            List<Prostorija> prostorije = new List<Prostorija>();
            foreach (Prostorija p in sveProstorije)
            {
                if (p.vrsta == vrsta)
                    prostorije.Add(p);
            }

            return prostorije;
        }

        public Boolean KreirajProstoriju(String idNoveProstorije, VrstaProstorije vrsta, int sprat, double kvadratura)
        {
            if(Pronadji(idNoveProstorije) != null)
            {
                return false;
            }
           
            Prostorija novaProstorija = new Prostorija(idNoveProstorije, sprat, vrsta, kvadratura);
                
            List<Prostorija> prostorije = DobaviSve();
            prostorije.Add(novaProstorija);
            Sacuvaj(prostorije);
            return true;

            
        }

        public List<int> DobaviKreveteZaSobu(Prostorija soba)
        {
            List<int> krevetiId = new List<int>();
            foreach (Inventar i in soba.inventar)
            {
                if (i.ime == "krevet")
                    krevetiId.Add(i.id);
            }
            return krevetiId;

        }

      

        

    }
}
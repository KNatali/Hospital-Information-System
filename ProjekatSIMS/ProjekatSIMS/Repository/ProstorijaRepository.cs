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
        

        public Boolean obrisiProstoriju(String idProstorijeZaBrisanje)
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

        public Prostorija pronadjiProstoriju(String Id)
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


        public List<Prostorija> DobaviOrdinacije()
        {
            List<Prostorija> sveProstorije = DobaviSve();
            List<Prostorija> ordinacije = new List<Prostorija>();
            foreach(Prostorija p in sveProstorije)
            {
                if (p.vrsta == VrstaProstorije.Ordinacija)
                    ordinacije.Add(p);
            }

            return ordinacije;
        }

        public List<Prostorija> DobaviSale()
        {
            List<Prostorija> sveProstorije = DobaviSveProstorije();
            List<Prostorija> ordinacije = new List<Prostorija>();
            foreach (Prostorija p in sveProstorije)
            {
                if (p.vrsta == VrstaProstorije.Sala)
                    ordinacije.Add(p);
            }

            return ordinacije;
        }

        public List<Prostorija> DobaviSobe()
        {
            List<Prostorija> sveProstorije = DobaviSveProstorije();
            List<Prostorija> sobe = new List<Prostorija>();
            foreach (Prostorija p in sveProstorije)
            {
                if (p.vrsta == VrstaProstorije.Soba)
                    sobe.Add(p);
            }

            return sobe;
        }

    }
}
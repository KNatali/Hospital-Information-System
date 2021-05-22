using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{

    public class ProstorijaRepository
    {
        public String LokacijaFajla{get; set;}
        public List<Prostorija> prostorije { get; set; }

        public ProstorijaRepository()
        {
            LokacijaFajla = @"..\..\..\Fajlovi\Prostorija.txt";
        }

        public ProstorijaRepository(String lokacija)
        {
            LokacijaFajla = lokacija;
        }
        public List<Prostorija> DobaviSveProstorije()
        {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);
            }
            return prostorije;
        }


        public void SacuvajProstorije(List<Prostorija> prostorije)
        {
            string json = JsonConvert.SerializeObject(prostorije);
            File.WriteAllText(LokacijaFajla, json);
        }

        public Boolean dodajProstoriju(Prostorija p)
        {
            //List<Prostorija> prostorije1 = DobaviSveProstorije();
            if (DobaviSveProstorije() == null)
            {
                prostorije.Add(p);
                SacuvajProstorije(prostorije);
                return true;
            }
            else
            {
                List<Prostorija> pr1 = DobaviSveProstorije();
                foreach(Prostorija pros in pr1)
                {
                    if(pros.id == p.id)
                    {
                        return false;
                    }
                }
                pr1.Add(p);
                SacuvajProstorije(pr1);
                return true;
            }
            



            

        }

        public Boolean obrisiProstoriju(Prostorija p)
        {
            foreach(Prostorija pros in prostorije)
            {
                if(p.id == pros.id)
                {
                    prostorije.Remove(p);
                    return true;
                    
                }
            }
            return false;
        }

        public Prostorija pronadjiProstoriju(String Id)
        {
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
            List<Prostorija> sveProstorije = DobaviSveProstorije();
            List<Prostorija> ordinacije = new List<Prostorija>();
            foreach(Prostorija p in sveProstorije)
            {
                if (p.vrsta == VrstaProstorije.Ordinacija)
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
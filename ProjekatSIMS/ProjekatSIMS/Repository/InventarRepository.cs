using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{

    
    public class InventarRepository
    {

        private const String putanja = @"..\..\..\Fajlovi\Prostorija.txt";

        public ProstorijaService ProstorijaService { get; private set; }

        public InventarRepository() { }
       

        public List<Inventar> DobaviSavInventar()
        {
            ProstorijaService = new ProstorijaService();
            List<Prostorija> prostorije = new List<Prostorija>();
            List<Inventar> inventar = new List<Inventar>();
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            foreach (Prostorija p in prostorije)
            {
                if (p.inventar != null)
                {
                    inventar.AddRange(p.inventar);
                    
                }
            }
            return inventar;
        }
        public List<Inventar> DobaviInventarPoVrsti(bool staticka)
        {
            ProstorijaService = new ProstorijaService();
            List<Prostorija> prostorije = new List<Prostorija>();
            List<Inventar> inventar = new List<Inventar>();
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            foreach (Prostorija p in prostorije)
            {
                if (p.inventar != null)
                {
                    foreach(Inventar i in p.inventar)
                    {
                        if(i.Staticka == staticka)
                        {
                            inventar.Add(i);
                            
                        }
                        

                    }

                }
            }
            
            return inventar;
        }
        public void Sacuvaj(List<Inventar> inventar)
        {
            string json = JsonConvert.SerializeObject(inventar);
            File.WriteAllText(putanja, json);
        }
        public Boolean ObrisiInventar(int id)
        {
            List<Inventar> inventar = new List<Inventar>();
            inventar = DobaviSavInventar();
            foreach (Inventar i in inventar)
            {
                if (i.id == id)
                {

                    inventar.Remove(i);
                    Sacuvaj(inventar);
                    return true;
                }
            }
            return false;
        }


        public List<Inventar> DobaviInventarIzProstorije(String idProstorije)
        {
            ProstorijaService = new ProstorijaService();
            List<Prostorija> prostorije = new List<Prostorija>();
            List<Inventar> inventar = new List<Inventar>();
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            foreach (Prostorija p in prostorije)
            {
                if (p.id == idProstorije)
                {
                    inventar.AddRange(p.inventar);
                    return inventar;
                }
            }
            return null;

        }

        public bool ObrisiInventar(int idOpremeZaBrisanje, String idProstorije)
        {
            ProstorijaService = new ProstorijaService();
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            foreach (Prostorija p in prostorije)
            {
                if (p.id == idProstorije)
                {
                    foreach(Inventar i in p.inventar)
                    {
                        if(i.id == idOpremeZaBrisanje)
                        {
                            p.inventar.Remove(i);
                            ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        }
   }
}
using System;
using System.Collections.Generic;
using System.Text;
using ProjekatSIMS.Repository;
using Repository;
using Model;

namespace ProjekatSIMS.Service
{
    public class ProstorijaService
    {
        public ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        public ProstorijaService() { }

        public Prostorija pronadjiProstorijuPoId(String idTrazeneProstorije)
        {
            List<Prostorija> prostorije = prostorijaRepository.DobaviSve();
            
            foreach(Prostorija p in prostorije)
            {
                if(p.id == idTrazeneProstorije)
                {
                    return p;
                }  
            }

            return null;
        }

        public Boolean obrisiProstoriju(String idProstorijeZaBrisanje)
        {
            List<Prostorija> prostorije = prostorijaRepository.DobaviSve();
            foreach(Prostorija p in prostorije)
            {
                if(p.id == idProstorijeZaBrisanje)
                {
                    prostorije.Remove(p);
                    prostorijaRepository.Sacuvaj(prostorije);
                    return true;
                }
            }
            return false;
            
        }
        
        
    }
}

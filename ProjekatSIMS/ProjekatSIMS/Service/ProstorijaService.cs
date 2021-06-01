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
        public bool daLiJeGlavniMagacin(String id, String vrsta)
        {
            Prostorija p = pronadjiProstorijuPoId(id);
            if(p.vrsta == VrstaProstorije.GlavniMagacin)
            {
                return true;
            }
            return false;
        }
        public VrstaProstorije kojaJeVrsta(String vrsta)
        {
            if (vrsta == VrstaProstorije.GlavniMagacin.ToString())
            {
                return VrstaProstorije.GlavniMagacin;
            }
            else
            if (vrsta == VrstaProstorije.Kancelarija.ToString())
            {
                return VrstaProstorije.Kancelarija;

            }
            else if (vrsta == VrstaProstorije.Ordinacija.ToString())
            {
                return VrstaProstorije.Ordinacija;
            }
            else if (vrsta == VrstaProstorije.Sala.ToString())
            {
                return VrstaProstorije.Sala;
            }
            else
                return VrstaProstorije.Soba;
        }
        public void IzmenaProstorije(String id, VrstaProstorije vrsta, int sprat, double kvadratura)
        {
            List<Prostorija> prostorije = prostorijaRepository.DobaviSve();
            foreach(Prostorija p in prostorije)
            {
                if(p.id == id)
                {
                    p.vrsta = vrsta;
                    p.kvadratura = kvadratura;
                    p.sprat = sprat;
                    prostorijaRepository.Sacuvaj(prostorije);
                    break;

                }
            }
            

        }
        public void KreiranjeProstorije(String id, VrstaProstorije vrsta, int sprat, double kvadratura)
        {
            List<Prostorija> prostorije = prostorijaRepository.DobaviSve();
            Prostorija novaProstorija = new Prostorija();
            novaProstorija.id = id;
            novaProstorija.vrsta = vrsta;
            novaProstorija.kvadratura = kvadratura;
            novaProstorija.sprat = sprat;
            novaProstorija.slobodna = true;
            novaProstorija.inventar = null;
            

        }
        
        
    }
}

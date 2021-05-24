using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class NotifikacijaService
   {
        public Repository.NotifikacijaRepository notifikacijaRepository = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");

        public List<Notifikacija> DobaviSve()
        {
            return notifikacijaRepository.DobaviSve();
        }
        public Boolean pisanjeObavestenja(Notifikacija notifikacija)
        {
            List<Notifikacija> sveNotifikacije = notifikacijaRepository.DobaviSve();
            sveNotifikacije.Add(novoObavestenje(notifikacija));
            notifikacijaRepository.Sacuvaj(sveNotifikacije);
            return true;
        }
        private Notifikacija novoObavestenje(Notifikacija poljeNotifikacije)
        {
            Notifikacija notifikacija = new Notifikacija();
            notifikacija.Naslov = poljeNotifikacije.Naslov;
            notifikacija.Tekst = poljeNotifikacije.Tekst;
            notifikacija.Datum = poljeNotifikacije.Datum;
            return notifikacija;
        }
        public Boolean cuvanjeIzmenjenjihPodataka(Notifikacija stariPodaci)
        {
            List<Notifikacija> novaListaObavestenja = new List<Notifikacija>();
            novaListaObavestenja = notifikacijaRepository.DobaviSve();
            foreach (Notifikacija noviPodaci in novaListaObavestenja)
            {
                ProveraIdObavestenja(stariPodaci, noviPodaci);
            }
            notifikacijaRepository.Sacuvaj(novaListaObavestenja);
            return true;
        }

        private static void ProveraIdObavestenja(Notifikacija stariPodaci, Notifikacija noviPodaci)
        {
            if (stariPodaci.Id == noviPodaci.Id)
            {
                IzmenaPodataka(stariPodaci, noviPodaci);
            }
        }

        private static void IzmenaPodataka(Notifikacija stariPodaci, Notifikacija noviPodaci)
        {
            noviPodaci.Naslov = stariPodaci.Naslov;
            noviPodaci.Tekst = stariPodaci.Tekst;
        }
    }
}
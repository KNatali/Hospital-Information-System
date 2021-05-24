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
        public Boolean PisanjeObavestenja(Notifikacija notifikacija)
        {
            List<Notifikacija> sveNotifikacije = notifikacijaRepository.DobaviSve();
            sveNotifikacije.Add(NovoObavestenje(notifikacija));
            notifikacijaRepository.Sacuvaj(sveNotifikacije);
            return true;
        }
        private Notifikacija NovoObavestenje(Notifikacija poljeNotifikacije)
        {
            Notifikacija notifikacija = new Notifikacija();
            notifikacija.Naslov = poljeNotifikacije.Naslov;
            notifikacija.Tekst = poljeNotifikacije.Tekst;
            notifikacija.Datum = poljeNotifikacije.Datum;
            return notifikacija;
        }
        public Boolean CuvanjeIzmenjenjihPodataka(Notifikacija stariPodaci)
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
        public Boolean ObrisiObavestenje(Notifikacija notifikacija)
        {
            List<Notifikacija> svaObavestenja = new List<Notifikacija>();
            svaObavestenja = notifikacijaRepository.DobaviSve();
            PretragaObavestenja(notifikacija, svaObavestenja);
            notifikacijaRepository.Sacuvaj(svaObavestenja);
            return true;
        }

        private static void PretragaObavestenja(Notifikacija notifikacija, List<Notifikacija> svaObavestenja)
        {
            foreach (Notifikacija n in svaObavestenja)
            {
                if (n.Id == notifikacija.Id)
                {
                    svaObavestenja.Remove(n);
                    break;
                }
            }
        }
    }
}
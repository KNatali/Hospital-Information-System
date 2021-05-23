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
        public Boolean pisanjeObavestenja(String naslov, String tekst, DateTime datumObjavljivanja)
        {
            List<Notifikacija> sveNotifikacije = notifikacijaRepository.DobaviSve();
            sveNotifikacije.Add(novoObavestenje(naslov,tekst,datumObjavljivanja));
            notifikacijaRepository.Sacuvaj(sveNotifikacije);
            return true;
        }
        private Notifikacija novoObavestenje(String naslov, String tekst, DateTime datumObjavljivanja)
        {
            Notifikacija notifikacija = new Notifikacija();
            notifikacija.Naslov = naslov;
            notifikacija.Tekst = tekst;
            notifikacija.Datum = datumObjavljivanja;
            return notifikacija;
        }
    }
}
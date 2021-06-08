using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using Model;
using ProjekatSIMS.Model;

namespace ProjekatSIMS.Service
{
    public class KreiranjeProfila
    {
        public PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        public DoktorRepository doktorRepository = new DoktorRepository(@"..\..\..\Fajlovi\Doktor.txt");
        public List<Pacijent> DobaviSvePacijente()
        {
            return pacijentRepository.DobaviSve();
        }
        public List<Doktor> DobaviSveDoktore()
        {
            return doktorRepository.DobaviSve();
        }
        public Boolean KreirajProfil(Uloga uloga, Osoba osoba)
        {
            if(uloga==Uloga.Doktor)
            {
                Doktor doktor = new Doktor();
                List<Doktor> sviDoktori = doktorRepository.DobaviSve();
                sviDoktori.Add(NoviDoktor(osoba));
                doktorRepository.Sacuvaj(sviDoktori);
            }
            else if(uloga==Uloga.Pacijent)
            {
                Pacijent pacijent = new Pacijent();
                List<Pacijent> sviPacijenti = pacijentRepository.DobaviSve();
                sviPacijenti.Add(NoviPacijent(osoba));
                pacijentRepository.Sacuvaj(sviPacijenti);
            }
            return true;
        }
        private Pacijent NoviPacijent(Osoba osoba)
        {
            Pacijent pacijent = new Pacijent();
            pacijent.Jmbg = osoba.Jmbg;
            pacijent.Ime = osoba.Ime;
            pacijent.Prezime = osoba.Prezime;
            pacijent.DatumRodjenja = osoba.DatumRodjenja;
            pacijent.BrojTelefona = osoba.BrojTelefona;
            pacijent.Email = osoba.Email;
            pacijent.Adresa = osoba.Adresa;
            return pacijent;
        }
        private Doktor NoviDoktor(Osoba osoba)
        {
            Doktor doktor = new Doktor();
            doktor.Jmbg = osoba.Jmbg;
            doktor.Ime = osoba.Ime;
            doktor.Prezime = osoba.Prezime;
            doktor.DatumRodjenja = osoba.DatumRodjenja;
            doktor.BrojTelefona = osoba.BrojTelefona;
            doktor.Email = osoba.Email;
            doktor.Adresa = osoba.Adresa;
            return doktor;
        }
    }
}

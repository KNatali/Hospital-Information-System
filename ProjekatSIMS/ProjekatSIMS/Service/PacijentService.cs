﻿using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class PacijentService
    {
        public Repository.PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        public List<Pacijent> DobaviSve()
        {
            return pacijentRepository.DobaviSve();
        }
        public Boolean ProveraImePrezime(String ime, String prezime)
        {
            List<Pacijent> pacijenti = pacijentRepository.DobaviSve();
            foreach(Pacijent p in pacijenti)
            {
                if (p.Ime == ime && p.Prezime == prezime)
                {
                    break;
                }
            }
            return true;
        }
        public Boolean kreiranjeProfila(String jmbg, String ime, String prezime, DateTime datumRodjenja, String telefon, String mail, String adresa)
        {
            List<Pacijent> sviPacijenti = pacijentRepository.DobaviSve();
            sviPacijenti.Add(noviPacijent(jmbg, ime, prezime, datumRodjenja, telefon, mail, adresa));
            pacijentRepository.Sacuvaj(sviPacijenti);
            return true;
        }
        private Pacijent noviPacijent(String jmbg, String ime, String prezime, DateTime datumRodjenja, String telefon, String mail, String adresa)
        {
            Pacijent pacijent = new Pacijent();
            pacijent.Jmbg = jmbg;
            pacijent.Ime = ime;
            pacijent.Prezime = prezime;
            pacijent.DatumRodjenja = datumRodjenja;
            pacijent.BrojTelefona = telefon;
            pacijent.Email = mail;
            pacijent.Adresa = adresa;
            return pacijent;
        }
        /*public Boolean cuvanjeIzmenjenjihPodataka(Pacijent stariPodaci)
        {
            List<Pacijent> novaListaPacijenata = new List<Pacijent>();
            foreach (Pacijent noviPodaci in novaListaPacijenata)
            {
                if (stariPodaci.Jmbg == noviPodaci.Jmbg)
                {
                    noviPodaci.Ime = stariPodaci.Ime;
                    noviPodaci.Prezime = stariPodaci.Prezime;
                    noviPodaci.BrojTelefona = stariPodaci.BrojTelefona;
                    noviPodaci.Email = stariPodaci.Email;
                    noviPodaci.Adresa = stariPodaci.Adresa;
                }
            }
            pacijentRepository.Sacuvaj(novaListaPacijenata);
            return true;
        }*/
        public Boolean cuvanjeIzmenjenjihPodataka(String jmbg, String ime, String prezime, String telefon, String mail, String adresa)
        {
            List<Pacijent> novaListaPacijenata = new List<Pacijent>();
            foreach (Pacijent noviPodaci in novaListaPacijenata)
            {
                if (jmbg == noviPodaci.Jmbg)
                {
                    noviPodaci.Ime = ime;
                    noviPodaci.Prezime = prezime;
                    noviPodaci.BrojTelefona = telefon;
                    noviPodaci.Email = mail;
                    noviPodaci.Adresa = adresa;
                }
            }
            pacijentRepository.Sacuvaj(novaListaPacijenata);
            return true;
        }
    }
}

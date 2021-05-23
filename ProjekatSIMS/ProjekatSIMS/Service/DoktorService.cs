using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using Model;

namespace Service
{
    public class DoktorService
    {
        public Repository.DoktorRepository doktorRepository = new DoktorRepository(@"..\..\..\Fajlovi\Doktor.txt");
        public List<Doktor> DobaviSve()
        {
            return doktorRepository.DobaviSve();
        }
        public Boolean kreiranjeProfila(String jmbg, String ime, String prezime, DateTime datumRodjenja, String telefon, String mail, String adresa, Specijalizacija specijalizacija, String pocetakRadnogVremena, String krajRadnogVremena)
        {
            List<Doktor> sviDoktori = doktorRepository.DobaviSve();
            sviDoktori.Add(noviDoktor(jmbg, ime, prezime, datumRodjenja, telefon, mail, adresa, specijalizacija, pocetakRadnogVremena, krajRadnogVremena));
            doktorRepository.Sacuvaj(sviDoktori);
            return true;
        }
        private Doktor noviDoktor(String jmbg, String ime, String prezime, DateTime datumRodjenja, String telefon, String mail, String adresa, Specijalizacija specijalizacija, String pocetakRadnogVremena, String krajRadnogVremena)
        {
            Doktor doktor = new Doktor();
            doktor.Jmbg = jmbg;
            doktor.Ime = ime;
            doktor.Prezime = prezime;
            doktor.DatumRodjenja = datumRodjenja;
            doktor.BrojTelefona = telefon;
            doktor.Email = mail;
            doktor.Adresa = adresa;
            doktor.Specijalizacija = specijalizacija;
            doktor.PocetakRadnogVremena = pocetakRadnogVremena;
            doktor.KrajRadnogVremena = krajRadnogVremena;
            return doktor;
        }
    }
}

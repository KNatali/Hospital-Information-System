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
        public Boolean KreirajProfil(Uloga uloga)
        {
            if(uloga==Uloga.Doktor)
            {
                Doktor doktor = new Doktor();
                List<Doktor> sviDoktori = doktorRepository.DobaviSve();
                sviDoktori.Add(NoviDoktor(doktor));
                doktorRepository.Sacuvaj(sviDoktori);
            }
            else if(uloga==Uloga.Pacijent)
            {
                Pacijent pacijent = new Pacijent();
                List<Pacijent> sviPacijenti = pacijentRepository.DobaviSve();
                sviPacijenti.Add(NoviPacijent(pacijent));
                pacijentRepository.Sacuvaj(sviPacijenti);
            }
            return true;
        }
        private Pacijent NoviPacijent(Pacijent poljePacijenta)
        {
            Pacijent pacijent = new Pacijent();
            pacijent.Jmbg = poljePacijenta.Jmbg;
            pacijent.Ime = poljePacijenta.Ime;
            pacijent.Prezime = poljePacijenta.Prezime;
            pacijent.DatumRodjenja = poljePacijenta.DatumRodjenja;
            pacijent.BrojTelefona = poljePacijenta.BrojTelefona;
            pacijent.Email = poljePacijenta.Email;
            pacijent.Adresa = poljePacijenta.Adresa;
            return pacijent;
        }
        private Doktor NoviDoktor(Doktor poljeDoktora)
        {
            Doktor doktor = new Doktor();
            doktor.Jmbg = poljeDoktora.Jmbg;
            doktor.Ime = poljeDoktora.Ime;
            doktor.Prezime = poljeDoktora.Prezime;
            doktor.DatumRodjenja = poljeDoktora.DatumRodjenja;
            doktor.BrojTelefona = poljeDoktora.BrojTelefona;
            doktor.Email = poljeDoktora.Email;
            doktor.Adresa = poljeDoktora.Adresa;
            //doktor.Specijalizacija = poljeDoktora.Specijalizacija;
            //doktor.PocetakRadnogVremena = poljeDoktora.PocetakRadnogVremena;
            //doktor.KrajRadnogVremena = poljeDoktora.KrajRadnogVremena;
            return doktor;
        }
    }
}

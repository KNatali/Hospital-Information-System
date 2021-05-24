using Model;
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
            if(jmbg!=null || ime!=null || prezime!=null)
            {
                sviPacijenti.Add(noviPacijent(jmbg, ime, prezime, datumRodjenja, telefon, mail, adresa));
                pacijentRepository.Sacuvaj(sviPacijenti);
                return true;
            }
            return false;
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
    }
}

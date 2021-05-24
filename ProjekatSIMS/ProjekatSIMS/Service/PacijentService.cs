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
        public Boolean kreiranjeProfila(Pacijent pacijent)
        {
            List<Pacijent> sviPacijenti = pacijentRepository.DobaviSve();
            sviPacijenti.Add(noviPacijent(pacijent));
            pacijentRepository.Sacuvaj(sviPacijenti);
            return true;
        }
        private Pacijent noviPacijent(Pacijent poljePacijenta)
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
        public Boolean cuvanjeIzmenjenjihPodataka(Pacijent stariPodaci)
        {
            List<Pacijent> novaListaPacijenata = new List<Pacijent>();
            novaListaPacijenata = pacijentRepository.DobaviSve();
            foreach (Pacijent noviPodaci in novaListaPacijenata)
            {
                ProveraJmbgPacijenta(stariPodaci, noviPodaci);
            }
            pacijentRepository.Sacuvaj(novaListaPacijenata);
            return true;
        }

        private static void ProveraJmbgPacijenta(Pacijent stariPodaci, Pacijent noviPodaci)
        {
            if (stariPodaci.Jmbg == noviPodaci.Jmbg)
            {
                IzmenaPodataka(stariPodaci, noviPodaci);
            }
        }

        private static void IzmenaPodataka(Pacijent stariPodaci, Pacijent noviPodaci)
        {
            noviPodaci.Ime = stariPodaci.Ime;
            noviPodaci.Prezime = stariPodaci.Prezime;
            noviPodaci.BrojTelefona = stariPodaci.BrojTelefona;
            noviPodaci.Email = stariPodaci.Email;
            noviPodaci.Adresa = stariPodaci.Adresa;
        }
    }
}

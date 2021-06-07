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
        public Boolean KreiranjeProfila(Doktor doktor)
        {
            List<Doktor> sviDoktori = doktorRepository.DobaviSve();
            sviDoktori.Add(NoviDoktor(doktor));
            doktorRepository.Sacuvaj(sviDoktori);
            return true;
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
            doktor.Specijalizacija = poljeDoktora.Specijalizacija;
            doktor.PocetakRadnogVremena = poljeDoktora.PocetakRadnogVremena;
            doktor.KrajRadnogVremena = poljeDoktora.KrajRadnogVremena;
            return doktor;
        }
        public Boolean CuvanjeIzmenjenjihPodataka(Doktor stariPodaci)
        {
            List<Doktor> novaListaDoktora = new List<Doktor>();
            novaListaDoktora = doktorRepository.DobaviSve();
            foreach (Doktor noviPodaci in novaListaDoktora)
            {
                ProveraJmbgDoktora(stariPodaci, noviPodaci);
            }
            doktorRepository.Sacuvaj(novaListaDoktora);
            return true;
        }

        private static void ProveraJmbgDoktora(Doktor stariPodaci, Doktor noviPodaci)
        {
            if (stariPodaci.Jmbg == noviPodaci.Jmbg)
            {
                IzmenaPodataka(stariPodaci, noviPodaci);
            }
        }
        private static void IzmenaPodataka(Doktor stariPodaci, Doktor noviPodaci)
        {
            noviPodaci.Ime = stariPodaci.Ime;
            noviPodaci.Prezime = stariPodaci.Prezime;
            noviPodaci.BrojTelefona = stariPodaci.BrojTelefona;
            noviPodaci.Email = stariPodaci.Email;
            noviPodaci.Specijalizacija = stariPodaci.Specijalizacija;
            noviPodaci.PocetakRadnogVremena = stariPodaci.PocetakRadnogVremena;
            noviPodaci.KrajRadnogVremena = stariPodaci.KrajRadnogVremena;
        }
        public Boolean ObrisiDoktora(Doktor profilDoktora)
        {
            List<Doktor> sviDoktori = new List<Doktor>();
            sviDoktori = doktorRepository.DobaviSve();
            PretragaDoktora(profilDoktora, sviDoktori);
            doktorRepository.Sacuvaj(sviDoktori);
            return true;
        }

        private static void PretragaDoktora(Doktor profilDoktora, List<Doktor> sviDoktori)
        {
            foreach (Doktor doktor in sviDoktori)
            {
                if (doktor.Jmbg == profilDoktora.Jmbg)
                {
                    sviDoktori.Remove(doktor);
                    break;
                }
            }
        }
    }
}

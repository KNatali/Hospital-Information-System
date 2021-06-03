using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;

namespace ProjekatSIMS.Service
{
    public class KreiranjePodsetnikaService
    {

        public PodsetnikRepository podsetnikRepository = new PodsetnikRepository();
        public PacijentRepository pacijentRepository = new PacijentRepository();


        private Podsetnik PostavljanjeAtributaPodsetnika(String naziv, String opis, DateTime datumPocetka, DateTime datumKraja, String jmbgPacijenta)
        {
            if (DaLiPostojiPacijent(jmbgPacijenta) != null)
            {
                Podsetnik podsetnik = new Podsetnik { nazivPodsetika = naziv, opisPodsetnika = opis, datumPocetkaObavestenja = datumPocetka, datumZavrsetkaObavestenja = datumKraja, pacijent = DaLiPostojiPacijent(jmbgPacijenta) };
                return podsetnik;
            }
            return null;
        }

        public Boolean kreiranjePodsetnika(String naziv, String opis, DateTime pocetakObavestenja, DateTime krajObavestenja, String jmbgPacijenta)
        {
            List<Podsetnik> podsetnici = podsetnikRepository.DobaviSvePodsetnike();
            podsetnici.Add(PostavljanjeAtributaPodsetnika(naziv, opis, pocetakObavestenja, krajObavestenja, jmbgPacijenta));
            podsetnikRepository.SacuvajPodsetnik(podsetnici);
            return true;
        }

        private String DaLiPostojiPacijent(String jmbg)
        {
            Pacijent pacijent = new Pacijent();
            List<Pacijent> pacijenti = pacijentRepository.DobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if ((p.Jmbg == jmbg))
                {
                    pacijent = p;
                }
            }
            return pacijent.Jmbg;
        }
    }
}

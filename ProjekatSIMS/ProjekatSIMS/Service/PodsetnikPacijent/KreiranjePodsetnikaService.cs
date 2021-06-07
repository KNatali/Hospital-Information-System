using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.Service.PretragaPacijent;
using Repository;
using System;
using System.Collections.Generic;

namespace ProjekatSIMS.Service
{
    public class KreiranjePodsetnikaService
    {

        public PodsetnikRepository podsetnikRepository = new PodsetnikRepository();
        public PacijentRepository pacijentRepository = new PacijentRepository();
        public TrazenjePacijentaService trazenjePacijenta = new TrazenjePacijentaService();


        private Podsetnik PostavljanjeAtributaPodsetnika(String naziv, String opis, DateTime datumPocetka, DateTime datumKraja, Pacijent pacijent)
        {
            if (trazenjePacijenta.PronalazenjePacijenta(pacijent) != null)
            {
                Podsetnik podsetnik = new Podsetnik { nazivPodsetika = naziv, opisPodsetnika = opis, datumPocetkaObavestenja = datumPocetka, datumZavrsetkaObavestenja = datumKraja, pacijent = trazenjePacijenta.PronalazenjePacijenta(pacijent).Jmbg };
                return podsetnik;
            }
            return null;
        }

        public Boolean kreiranjePodsetnika(String naziv, String opis, DateTime pocetakObavestenja, DateTime krajObavestenja, Pacijent pacijent)
        {
            List<Podsetnik> podsetnici = podsetnikRepository.DobaviSvePodsetnike();
            podsetnici.Add(PostavljanjeAtributaPodsetnika(naziv, opis, pocetakObavestenja, krajObavestenja, pacijent));
            podsetnikRepository.SacuvajPodsetnik(podsetnici);
            return true;
        }

  
    }
}

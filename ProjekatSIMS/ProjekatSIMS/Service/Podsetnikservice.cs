using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
   
    public class Podsetnikservice
    {
        public PodsetnikRepository podsetnikRepository = new PodsetnikRepository();
        

        public Boolean kreiranjePodsetnika(String naziv,String opis, DateTime pocetakObavestenja, DateTime krajObavestenja,String imePacijenta,String prezimePacijenta)
        {
            

            Podsetnik podsetnik = new Podsetnik();
            if(DaLiPostojiPacijent(imePacijenta,prezimePacijenta) != null)
            {
                podsetnik.pacijent = DaLiPostojiPacijent(imePacijenta, prezimePacijenta);

            }
            

            List<Podsetnik> podsetnici = podsetnikRepository.DobaviSvePodsetnikeZaPacijenta(imePacijenta,prezimePacijenta);

            podsetnik.nazivPodsetika = naziv;
            podsetnik.opisPodsetnika = opis;
            podsetnik.datumPocetkaObavestenja = pocetakObavestenja;
            podsetnik.datumZavrsetkaObavestenja = krajObavestenja;
            podsetnici.Add(podsetnik);
            podsetnikRepository.SacuvajPodsetnik(podsetnici);

            return true;
        }

        private Pacijent DaLiPostojiPacijent(String imePacijenta, String prezimePacijenta)
        {
            Pacijent pacijent = new Pacijent();
            PacijentRepository pacijentRepo = new PacijentRepository();
            List<Pacijent> pacijenti = pacijentRepo.DobaviSve();

            foreach (Pacijent p in pacijenti)
            {
                if ((p.Ime == imePacijenta) & (p.Prezime == prezimePacijenta))
                {
                    pacijent = p;
                }
            }
            return pacijent;
        }
    }
}

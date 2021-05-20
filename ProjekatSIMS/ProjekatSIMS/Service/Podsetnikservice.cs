using Microsoft.Toolkit.Uwp.Notifications;
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
        public PacijentRepository pacijentRepository = new PacijentRepository();
        

        private Podsetnik PostavljanjeAtributaPodsetnika(String naziv,String opis, DateTime datumPocetka, DateTime datumKraja, String imePacijenta, String prezimePacijenta)
        {
            Podsetnik podsetnik = new Podsetnik();
            podsetnik.nazivPodsetika = naziv;
            podsetnik.opisPodsetnika = opis;
            podsetnik.datumPocetkaObavestenja = datumPocetka;
            podsetnik.datumZavrsetkaObavestenja = datumKraja;
            if (DaLiPostojiPacijent(imePacijenta, prezimePacijenta) != null)
            {
                podsetnik.pacijent = DaLiPostojiPacijent(imePacijenta, prezimePacijenta);
            }
            return podsetnik;
        }

        public void PrikazivanjePodsetnika()
        {
            
            
        }

        public Boolean kreiranjePodsetnika(String naziv,String opis, DateTime pocetakObavestenja, DateTime krajObavestenja,String imePacijenta,String prezimePacijenta)
        {
            List<Podsetnik> podsetnici = podsetnikRepository.DobaviSvePodsetnike();
            podsetnici.Add(PostavljanjeAtributaPodsetnika(naziv, opis, pocetakObavestenja, krajObavestenja,imePacijenta,prezimePacijenta));
            podsetnikRepository.SacuvajPodsetnik(podsetnici);
            return true;
        }

        private Pacijent DaLiPostojiPacijent(String imePacijenta, String prezimePacijenta)
        {
            Pacijent pacijent = new Pacijent();
            List<Pacijent> pacijenti = pacijentRepository.UcitajSvePacijente();
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

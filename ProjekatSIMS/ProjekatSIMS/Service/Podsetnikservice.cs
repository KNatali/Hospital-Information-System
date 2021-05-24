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
            if (DaLiPostojiPacijent(imePacijenta, prezimePacijenta) != null)
            {
                Podsetnik podsetnik = new Podsetnik { nazivPodsetika = naziv, opisPodsetnika = opis, datumPocetkaObavestenja = datumPocetka, datumZavrsetkaObavestenja = datumKraja, pacijent = DaLiPostojiPacijent(imePacijenta, prezimePacijenta)};
                return podsetnik;
            }
            return null;
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
            List<Pacijent> pacijenti = pacijentRepository.DobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if ((p.Ime == imePacijenta) & (p.Prezime == prezimePacijenta))
                {
                    pacijent = p;
                }
            }
            return pacijent;
        }

        public Boolean DaLiTrebaPoslatiObavestenje(DateTime krajObavestenja, DateTime pocetakObavestenja)
        {
            int porediKrajSaSadasnjim = DateTime.Compare(krajObavestenja, DateTime.UtcNow);
            int porediPocetakSaSadasnjim = DateTime.Compare(pocetakObavestenja, DateTime.UtcNow);
            if ((porediKrajSaSadasnjim >= 0) && (porediPocetakSaSadasnjim <= 0))
            {
                return true;
            }
            return false;
        }
    }
}

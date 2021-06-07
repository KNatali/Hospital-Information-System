using System;
using Model;
using Repository;
using System.Collections.Generic;
using System.Text;
using ProjekatSIMS.Model;

namespace Service
{
    public class HitanPregledService
    {
        public Repository.HitanPregledRepository hpRepository = new HitanPregledRepository();
        public List<Pacijent> DobaviSvePacijente()
        {
            return hpRepository.DobaviSvePacijente();
        }
        public Boolean KreiranjeHitnogProfila(Pacijent pacijent)
        {
            List<Pacijent> sviPacijenti = hpRepository.DobaviSvePacijente();
            sviPacijenti.Add(NoviPacijent(pacijent));
            hpRepository.SacuvajHitanNalog(sviPacijenti);
            return true;
        }
        private Pacijent NoviPacijent(Pacijent poljePacijenta)
        {
            Pacijent pacijent = new Pacijent();
            pacijent.Jmbg = poljePacijenta.Jmbg;
            pacijent.Ime = poljePacijenta.Ime;
            pacijent.Prezime = poljePacijenta.Prezime;
            return pacijent;
        }
        public Boolean ZakazivanjeKodDoktoraOpstePrakse(Pregled pregled, Pacijent pacijent)
        {
            List<Pregled> sviPregledi = hpRepository.DobaviSvePreglede();
            sviPregledi.Add(ZakaziPregledOP(pregled, pacijent));
            hpRepository.SacuvajPregled(sviPregledi);
            return true;
        }
        private Pregled ZakaziPregledOP(Pregled pregled, Pacijent pacijent)
        {
            pregled = new Pregled();
            List<SlobodanTermin> slobodniTermini = new List<SlobodanTermin>();
            foreach (SlobodanTermin st in slobodniTermini)
            {
                if(st.doktor.Specijalizacija==Specijalizacija.Opsta)
                {
                    if (DateTime.Compare(st.PocetakTermina, DateTime.Now) >= 0 && DateTime.Compare(st.PocetakTermina, DateTime.Now.AddMinutes(30)) <= 0)
                    {
                        pregled.pacijent = pacijent;
                        pregled.Pocetak = st.PocetakTermina;
                        pregled.doktor = st.doktor;
                    }
                }
            }
            return pregled;
        }
        public Boolean ZakazivanjeKodDoktoraHirurga(Pregled pregled, Pacijent pacijent)
        {
            List<Pregled> sviPregledi = hpRepository.DobaviSvePreglede();
            sviPregledi.Add(ZakaziPregleH(pregled, pacijent));
            hpRepository.SacuvajPregled(sviPregledi);
            return true;
        }
        private Pregled ZakaziPregleH(Pregled pregled, Pacijent pacijent)
        {
            pregled = new Pregled();
            List<SlobodanTermin> slobodniTermini = new List<SlobodanTermin>();
            foreach (SlobodanTermin st in slobodniTermini)
            {
                if (st.doktor.Specijalizacija == Specijalizacija.Hirurgija)
                {
                    if (DateTime.Compare(st.PocetakTermina, DateTime.Now) >= 0 && DateTime.Compare(st.PocetakTermina, DateTime.Now.AddMinutes(30)) <= 0)
                    {
                        pregled.pacijent = pacijent;
                        pregled.Pocetak = st.PocetakTermina;
                        pregled.doktor = st.doktor;
                    }
                }
            }
            return pregled;
        }
        public Boolean ZakazivanjeKodDoktoraKardiologa(Pregled pregled, Pacijent pacijent)
        {
            List<Pregled> sviPregledi = hpRepository.DobaviSvePreglede();
            sviPregledi.Add(ZakaziPregledK(pregled, pacijent));
            hpRepository.SacuvajPregled(sviPregledi);
            return true;
        }
        private Pregled ZakaziPregledK(Pregled pregled, Pacijent pacijent)
        {
            pregled = new Pregled();
            List<SlobodanTermin> slobodniTermini = new List<SlobodanTermin>();
            foreach (SlobodanTermin st in slobodniTermini)
            {
                if (st.doktor.Specijalizacija == Specijalizacija.Kardiologija)
                {
                    if (DateTime.Compare(st.PocetakTermina, DateTime.Now) >= 0 && DateTime.Compare(st.PocetakTermina, DateTime.Now.AddMinutes(30)) <= 0)
                    {
                        pregled.pacijent = pacijent;
                        pregled.Pocetak = st.PocetakTermina;
                        pregled.doktor = st.doktor;
                    }
                }
            }
            return pregled;
        }
    }
}

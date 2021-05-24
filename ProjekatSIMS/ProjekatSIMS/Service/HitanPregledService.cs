using System;
using Model;
using Repository;
using System.Collections.Generic;
using System.Text;

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
    }
}

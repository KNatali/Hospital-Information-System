using Model;
using ProjekatSIMS.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.PregledDoktor
{
    public class PrikazPregledaDoktorService
    {
        private DoktorRepository doktorRepository = new DoktorRepository();
        private PregledRepository pregledRepository = new PregledRepository();
        public List<Pregled> PrikazPregleda()
        {
            List<Doktor> doktori = doktorRepository.DobaviSve();
            Doktor doktor = doktorRepository.DobaviByRegistracija(UlogovaniKorisnik.KorisnickoIme, UlogovaniKorisnik.Lozinka);
             return pregledRepository.DobaviZakazanePregledeDoktora(doktor);
        }
    }
}

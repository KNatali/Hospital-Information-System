using Model;
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
            Doktor doktor = new Doktor();
            foreach (Doktor d in doktori)
            {
                if (d.Jmbg == "1511990855023")
                {
                    doktor = d;
                    break;
                }
            }
            return pregledRepository.DobaviZakazanePregledeDoktora(doktor);
        }
    }
}

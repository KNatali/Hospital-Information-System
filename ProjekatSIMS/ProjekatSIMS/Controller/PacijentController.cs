using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class PacijentController
    {
        public Service.PacijentService pacijentService = new PacijentService();
        public List<Pacijent> DobaviSve()
        {
            return pacijentService.DobaviSve();
        }
        public Boolean ProveraImePrezime(String ime, String prezime)
        {
            if (pacijentService.ProveraImePrezime(ime, prezime))
                return true;
            return false;
        }
        public Boolean kreiranjeProfila(String jmbg, String ime, String prezime, DateTime datumRodjenja, String telefon, String mail, String adresa)
        {
            if (pacijentService.kreiranjeProfila(jmbg, ime, prezime, datumRodjenja, telefon, mail, adresa) == true)
                return true;
            else
                return false;
        }
        /*public Boolean cuvanjeIzmenjenjihPodataka(Pacijent stariPodaci)
        {
            if (pacijentService.cuvanjeIzmenjenjihPodataka(stariPodaci))
                return true;
            else
                return false;
        }*/
        public Boolean cuvanjeIzmenjenjihPodataka(String jmbg, String ime, String prezime, String telefon, String mail, String adresa)
        {
            if (pacijentService.cuvanjeIzmenjenjihPodataka(jmbg, ime, prezime, telefon, mail, adresa))
                return true;
            else
                return false;
        }
    }
}

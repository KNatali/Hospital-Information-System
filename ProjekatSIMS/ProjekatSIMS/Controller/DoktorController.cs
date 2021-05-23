using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public class DoktorController
    {
        public Service.DoktorService doktorService = new DoktorService();
        public List<Doktor> DobaviSve()
        {
            return doktorService.DobaviSve();
        }
        public Boolean kreiranjeProfila(String jmbg, String ime, String prezime, DateTime datumRodjenja, String telefon, String mail, String adresa, Specijalizacija specijalizacija, String pocetakRadnogVremena, String krajRadnogVremena)
        {
            if (doktorService.kreiranjeProfila(jmbg, ime, prezime, datumRodjenja, telefon, mail, adresa, specijalizacija, pocetakRadnogVremena, krajRadnogVremena) == true)
                return true;
            else
                return false;
        }
    }
}

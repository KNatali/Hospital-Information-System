using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Model
{
    public class SlobodanTermin

    {

        public DateTime Termin { get; set; }
        public String ImeDoktora { get; set; }
        public String PrezimeDoktora { get; set; }
        public Doktor doktor { get; set; }
        public bool Slobodan { get; set; }
        public Specijalizacija Specijalizacija { get; set; }

        public SlobodanTermin(DateTime termin, String ime, String prezime, bool sl)
        {
            Termin = termin;
            doktor.Ime = ime;
            doktor.Prezime = prezime;
            Slobodan = sl;
            
        }
        public SlobodanTermin()
        {
            Termin = new DateTime();
            doktor.Ime = "";
            doktor.Prezime = "";
            Slobodan = true;
        }


    }
}

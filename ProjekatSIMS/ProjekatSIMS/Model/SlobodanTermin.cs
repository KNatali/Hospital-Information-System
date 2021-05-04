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
        public DateTime PocetakTermina { get; set; }
        public DateTime KrajTermina { get; set; }

        public SlobodanTermin(DateTime termin, String ime, String prezime, bool sl)
        {
            Termin = termin;
            doktor.Ime = ime;
            doktor.Prezime = prezime;
            Slobodan = sl;
            
        }
        public SlobodanTermin()
        {
            /*Termin = new DateTime();
            doktor.Ime = "";
            doktor.Prezime = "";
            Slobodan = true;*/
        }

        public SlobodanTermin(DateTime noviPocetak, int sati, int minuti)
        {
            int dan = noviPocetak.Day;
            int mesec = noviPocetak.Month;
            int godina = noviPocetak.Year;
            DateTime NoviPocetakTermina = new DateTime(godina, mesec, dan, sati, minuti, 0);
            this.PocetakTermina = NoviPocetakTermina;
            this.KrajTermina = PocetakTermina.AddMinutes(30);
        }
        public SlobodanTermin(DateTime noviPocetak, int sati, int minuti, Doktor d)
        {
            int dan = noviPocetak.Day;
            int mesec = noviPocetak.Month;
            int year = noviPocetak.Year;
            DateTime NoviPocetakTermina = new DateTime(year, mesec, dan, sati, minuti, 0);
            this.PocetakTermina = NoviPocetakTermina;
            this.KrajTermina = PocetakTermina.AddMinutes(30);
            this.doktor = d;
        }
    }
}

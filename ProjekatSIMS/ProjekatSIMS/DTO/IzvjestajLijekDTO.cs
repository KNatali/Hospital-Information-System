using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.DTO
{
   public  class IzvjestajLijekDTO
    {
        private String sifra;
        private String naziv;
     
        private int kolicina;

        public IzvjestajLijekDTO(string sifra,string naziv, int kolicina)
        {
            this.Sifra = sifra;
            this.Naziv = naziv;
        
            this.Kolicina = kolicina;
        }
        public string Sifra { get => sifra; set => sifra = value; }

        public string Naziv { get => naziv; set => naziv = value; }

        public int Kolicina { get => kolicina; set => kolicina = value; }
    }
}

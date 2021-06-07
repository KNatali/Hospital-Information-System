using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Lijek
    {
        public String Id { get; set; }
        public String NazivLeka { get; set; } 
        public List<String> Alergeni { get; set; }
        public String Opis{get; set;}

        public OdobravanjeLekaEnum Status { get; set; }
        



        public List<String> AlternativniLekovi { get; set; }

        public String PorukaOdbaci { get; set; }

        public Lijek(){ }
        public Lijek(String i,String n, String o, List<String> al, List<String> aler, OdobravanjeLekaEnum od)
        {
            this.Id = i;
            this.NazivLeka = n;
            this.Opis = o;
            this.Status = od;
            this.Alergeni =aler;
            this.AlternativniLekovi = al;
        }
        public Lijek(String naziv, String opis, List<String> sastojci, List<String> alternativni)
        {
            this.NazivLeka = naziv;
            this.Opis = opis;
            this.Status = OdobravanjeLekaEnum.Ceka;
            this.Alergeni = sastojci;
            this.AlternativniLekovi = alternativni;
            this.PorukaOdbaci = "";

        }







    }
}

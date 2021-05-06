using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Lijek
    {
        public String NazivLeka { get; set; }
        public String Opis { get; set; }
        public OdobravanjeLekaEnum Status { get; set; }
        public List<Lijek> AlternativniLekovi { get; set; }
        public List<String> Alergeni { get; set; }


        public Lijek(){ }
        public Lijek(String n, String o, List<Lijek> al, List<String> aler, OdobravanjeLekaEnum od)
        {
            this.NazivLeka = n;
            this.Opis = o;
            this.Status = od;
            this.Alergeni =aler;
            this.AlternativniLekovi = al;
        }

    }
}

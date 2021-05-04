using System;
using System.Collections.Generic;

namespace Model
{
    public class Lijek
    {
        public String NazivLeka { get; set; }

        public String Opis{get; set;}

        public OdobravanjeLekaEnum Status { get; set; }
        
        public List<String> Alergeni { get; set; }

        public List<String> AlternativniLekovi { get; set; }

        public String PorukaOdbaci { get; set; }



    }
}

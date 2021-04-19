

using System;
using System.Collections;

namespace Model
{
   public class Prostorija
   {

      
   
      public String id { get; set; }
      public int sprat { get; set; }
        public VrstaProstorije vrsta { get; set; }

        public Pregled[] pregled { get; set; }
        public Inventar[] inventar { get; set; }

        public bool slobodna { get; set; }

        public Prostorija(String id, int sprat, VrstaProstorije prostorija) {
            this.id = id;
            this.sprat = sprat;
            this.vrsta = prostorija;
        }
        public Prostorija() { }
        public Prostorija(String id, int sprat, VrstaProstorije prostorija, Pregled[] pregledi, Inventar[] inventar, bool sl)
        {
            this.id = id;
            this.sprat = sprat;
            this.vrsta = prostorija;
            this.pregled = pregledi;
            this.inventar = inventar;
            this.slobodna = sl;
        }

    

     
      
   
   }

     



}
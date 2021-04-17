

using System;

namespace Model
{
   public class Prostorija
   {
      
   
      public String id { get; set; }
      public int sprat { get; set; }
        public VrstaProstorije vrsta { get; set; }

        public Pregled[] pregled { get; set; }
        public Inventar[] inventar { get; set; }

    }
}
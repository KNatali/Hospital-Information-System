

using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
   public class Prostorija
   {
       
   
      public String id { get; set; }
      public int sprat { get; set; }
        public VrstaProstorije vrsta { get; set; }

        public double kvadratura { get; set; }

        public Pregled[] pregled { get; set; }

        public List<Inventar> inventar { get; set; }

        public bool slobodna { get; set; }
        public DateTime ZauzetaOd { get; set; }
        public DateTime ZauzetaDo { get; set; }

        public Prostorija(String id, int sprat, VrstaProstorije prostorija, double kvadratura) {
            this.id =id;
            this.sprat = sprat;
            this.vrsta = prostorija;
            this.kvadratura = kvadratura;
        }
        public Prostorija() 
        {
            //this.id = generisiId();
        }

        public Prostorija(String id, int sprat, VrstaProstorije prostorija, double kvadratura, Pregled[] pregledi, List<Inventar> inventar, bool sl)

        {
            this.id = id;
            this.sprat = sprat;
            this.vrsta = prostorija;
            this.pregled = pregledi;
            this.inventar = inventar;
            this.slobodna = sl;
            this.kvadratura = kvadratura;
        }

    

     
      
   
   }

     



}
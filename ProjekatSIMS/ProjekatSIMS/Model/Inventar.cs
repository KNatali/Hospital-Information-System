

using System;

namespace Model
{
   public class Inventar
   {
      
   
      public int id { get; set; }
      public int kolicina { get; set; }
        public String ime { get; set; }

        public Boolean Staticka { get; set; }

        public String prostorija { get; set; }

        public Inventar(int id, int kolicina, String ime, Boolean staticka, String pr) {
            this.id = id;
            this.kolicina = kolicina;
            this.ime = ime;
            this.Staticka = staticka;
            this.prostorija = pr;
            
        
        }
        public Inventar(int id, int kolicina, String ime, Boolean staticka)
        {
            this.id = id;
            this.kolicina = kolicina;
            this.ime = ime;
            this.Staticka = staticka;


        }
        public Inventar() { }
        


       
   
   }

}
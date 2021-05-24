
using System;

namespace Model
{
   public class Pregled
   {
      public Pregled(DateTime pocetak,int trajanje, TipPregleda tip,StatusPregleda status,Prostorija prostorija,Doktor doktor)
        {
            this.Pocetak = pocetak;
            this.Trajanje = trajanje;
            this.Tip = tip;
            this.StatusPregleda = status;
            this.prostorija = prostorija;
            this.doktor = doktor;
        }
        public Pregled()
        {

        }
      public Boolean ZakaziPregled()
      {
         // TODO: implement
         return true;
      }
      
      public Boolean OtkaziPregledDoktor()
      {
         // TODO: implement
         return true;
      }
      
      public Boolean PomjeriPregledDoktor(DateTime datum, int trajanje)
      {
         // TODO: implement
         return true;
      }
   
      public int Id { get; set; }


      public DateTime Pocetak { get; set;}
      public int Trajanje { get; set; }
      public TipPregleda Tip { get; set; }
      public StatusPregleda StatusPregleda { get; set; }
      
      public Prostorija prostorija { get; set; }
      public Doktor doktor { get; set; }
      
     
      public Doktor GetDoktor()

      {
         return doktor;
      }
      
      public void SetDoktor(Doktor newDoktor)
      {
         if (this.doktor != newDoktor)
         {
            if (this.doktor != null)
            {
               Doktor oldDoktor = this.doktor;
               this.doktor = null;
               oldDoktor.RemovePregled(this);
            }
            if (newDoktor != null)
            {
               this.doktor = newDoktor;
               this.doktor.AddPregled(this);
            }
         }
      }
        public Pacijent pacijent { get; set; }
    
      public Pacijent GetPacijent()
      {
         return pacijent;
      }
     
      public void SetPacijent(Pacijent newPacijent)
      {
         if (this.pacijent != newPacijent)
         {
            if (this.pacijent != null)
            {
               Pacijent oldPacijent = this.pacijent;
               this.pacijent = null;
               oldPacijent.RemovePregled(this);
            }
            if (newPacijent != null)
            {
               this.pacijent = newPacijent;
               this.pacijent.AddPregled(this);
            }
         }
      }
   
   }
}
/***********************************************************************
 * Module:  Pregled.cs
 * Author:  nata1
 * Purpose: Definition of the Class Pregled
 ***********************************************************************/

using System;

namespace Model
{
   public class Pregled
   {
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
      public DateTime Pocetak { get; set; }
      public int Trajanje { get; set; }
      public TipPregleda Tip { get; set; }
      public StatusPregleda StatusPergleda { get; set; }
      
      public Prostorija prostorija { get; set; }
      public Doktor doktor { get; set; }
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Doktor GetDoktor()
      {
         return doktor;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newDoktor</param>
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
      public Pacijent pacijent;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Pacijent GetPacijent()
      {
         return pacijent;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newPacijent</param>
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
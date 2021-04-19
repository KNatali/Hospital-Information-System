using System;

namespace Model
{
   public class Anamneza
   {
      public ZdravsteniKarton zdravsteniKarton { get; set; }
        public String OpisAnamneze { get; set; }
        public DateTime datum { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public ZdravsteniKarton GetZdravsteniKarton()
      {
         return zdravsteniKarton;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newZdravsteniKarton</param>
      public void SetZdravsteniKarton(ZdravsteniKarton newZdravsteniKarton)
      {
         if (this.zdravsteniKarton != newZdravsteniKarton)
         {
            if (this.zdravsteniKarton != null)
            {
               ZdravsteniKarton oldZdravsteniKarton = this.zdravsteniKarton;
               this.zdravsteniKarton = null;
               oldZdravsteniKarton.RemoveAnamneza(this);
            }
            if (newZdravsteniKarton != null)
            {
               this.zdravsteniKarton = newZdravsteniKarton;
               this.zdravsteniKarton.AddAnamneza(this);
            }
         }
      }
   
     
   
   }
}
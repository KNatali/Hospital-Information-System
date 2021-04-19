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
     
   
     
   
   }
}
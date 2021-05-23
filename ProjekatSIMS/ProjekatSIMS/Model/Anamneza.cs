using System;

namespace Model
{
   public class Anamneza
   {
        private ZdravsteniKarton zdravsteniKarton;
        private String OpisAnamneze;
        private DateTime datum; 

        public Anamneza()
        {

        }
        public Anamneza(ZdravsteniKarton zdravsteniKarton, string opisAnamneze, DateTime datum)
        {
            this.ZdravsteniKarton = zdravsteniKarton;
            OpisAnamneze1 = opisAnamneze;
            this.Datum = datum;
        }

        public ZdravsteniKarton ZdravsteniKarton { get => zdravsteniKarton; set => zdravsteniKarton = value; }
        public string OpisAnamneze1 { get => OpisAnamneze; set => OpisAnamneze = value; }
        public DateTime Datum { get => datum; set => datum = value; }

        public ZdravsteniKarton GetZdravsteniKarton()
      {
         return ZdravsteniKarton;
      }
      

     
   
     
   
   }
}
using System;

namespace Model
{
   public class Anamneza
   {
        
        private String opisAnamneze;
        private DateTime datum; 

        public Anamneza()
        {

        }
        public Anamneza( string opisAnamneze, DateTime datum)
        {
        
            this.OpisAnamneze= opisAnamneze;
            this.Datum = datum;
        }

     
        public string OpisAnamneze { get => opisAnamneze; set => opisAnamneze = value; }
        public DateTime Datum { get => datum; set => datum = value; }

      
      

     
   
     
   
   }
}
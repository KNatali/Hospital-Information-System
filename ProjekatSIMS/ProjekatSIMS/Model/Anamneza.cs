using System;

namespace Model
{
   public class Anamneza
   {
        private int id;
        private String opisAnamneze;
        private DateTime datum;
        private int idKartona;

        public Anamneza()
        {

        }
        public Anamneza(int id, string opisAnamneze, DateTime datum,int idKartona)
        {
            this.Id = id;
            this.OpisAnamneze= opisAnamneze;
            this.Datum = datum;
            this.idKartona = idKartona;
        }

        public int Id { get => id; set => id = value; }
        public int IdKartona { get => idKartona; set => idKartona = value; }
        public string OpisAnamneze { get => opisAnamneze; set => opisAnamneze = value; }
        public DateTime Datum { get => datum; set => datum = value; }

      
      

     
   
     
   
   }
}
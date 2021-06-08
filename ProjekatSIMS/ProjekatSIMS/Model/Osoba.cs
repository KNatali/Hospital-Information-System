using ProjekatSIMS.Model;
using System;

namespace Model
{
   public class Osoba
   {
      public String Jmbg { get; set; }



      public String Ime { get; set; }


        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String Email { get; set; }
        public String Adresa { get; set; }
        public String BrojTelefona { get; set; }
   }
}
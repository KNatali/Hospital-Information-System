using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
   public class Doktor : Osoba
   {
      public int BrojSlobodnihDana;
      public String PocetakRadnogVremena { get; set; }
      public String KrajRadnogVremena { get; set; }
      public Specijalizacija Specijalizacija { get; set; }

        public RegistrovaniKorisnik registrovaniKorisnik { get; set; }
   }
}
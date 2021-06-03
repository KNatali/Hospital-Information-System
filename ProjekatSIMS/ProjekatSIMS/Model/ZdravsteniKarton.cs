using System;
using System.Collections.Generic;

namespace Model
{
   public class ZdravsteniKarton
   {
      public List<Recept> Recepti { get; set; }
      public List<Anamneza> anamneza { get; set;}
      
   
      public String IdPacijent { get; set; }
   
      public List<String> Alergeni { get; set; }

        public List<UputBolnickoLijecenje> UputiZaBolnickoLijecenje { get; set; }
        public int Id { get; set; }
   
   }
}
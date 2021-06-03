using System;
using System.Collections.Generic;

namespace Model
{
   public class ZdravsteniKarton
   {
      public List<int> Recepti { get; set; }
      public List<int> anamneza { get; set;}
      
   
      public String IdPacijent { get; set; }
   
      public List<String> Alergeni { get; set; }

        public List<int> UputiZaBolnickoLijecenje { get; set; }
        public int Id { get; set; }
   
   }
}
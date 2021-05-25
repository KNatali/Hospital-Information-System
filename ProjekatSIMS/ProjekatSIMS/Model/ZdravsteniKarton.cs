using System;
using System.Collections.Generic;

namespace Model
{
   public class ZdravsteniKarton
   {
      public List<Recept> Recepti { get; set; }
      public List<Anamneza> anamneza { get; set;}
      
   
      public Pacijent pacijent { get; set; }
   
      public List<String> Alergeni { get; set; }
      public List<String> Terapija { get; set; }

        public List<UputBolnickoLijecenje> UputiZaBolnickoLijecenje { get; set; }

   
   }
}
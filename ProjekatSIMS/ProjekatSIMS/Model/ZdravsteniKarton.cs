using System;
using System.Collections.Generic;

namespace Model
{
   public class ZdravsteniKarton
   {
      public List<Recept> Recepti { get; set; }
      public List<Anamneza> anamneza { get; set;}
      
      /// <pdGenerated>default getter</pdGenerated>
      
      
      /// <pdGenerated>default setter</pdGenerated>
      

      /// <pdGenerated>default removeAll</pdGenerated>
      
      public Pacijent pacijent { get; set; }
   
      public List<String> Alergeni { get; set; }
      public List<String> Terapija { get; set; }

        public List<UputBolnickoLijecenje> UputiZaBolnickoLijecenje { get; set; }

   
   }
}
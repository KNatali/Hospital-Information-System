using System;
using System.Collections.Generic;

namespace Model
{
   public class ZdravsteniKarton
   {
      public Recept[] recept { get; set; }
      public List<Anamneza> anamneza { get; set;}
      
      /// <pdGenerated>default getter</pdGenerated>
      
      
      /// <pdGenerated>default setter</pdGenerated>
      
      public Pacijent pacijent;
   
      public List<String> Alergeni { get; set; }
     public List<String> Terapija { get; set; }
   
   }
}
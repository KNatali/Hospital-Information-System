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
      

      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllAnamneza()
      {
         if (anamneza != null)
         {
            System.Collections.ArrayList tmpAnamneza = new System.Collections.ArrayList();
            foreach (Anamneza oldAnamneza in anamneza)
               tmpAnamneza.Add(oldAnamneza);
            anamneza.Clear();
            foreach (Anamneza oldAnamneza in tmpAnamneza)
               oldAnamneza.SetZdravsteniKarton((ZdravsteniKarton)null);
            tmpAnamneza.Clear();
         }
      }
      public Pacijent pacijent { get; set; }
   
      public List<String> Alergeni { get; set; }
      public List<String> Terapija { get; set; }

   
   }
}
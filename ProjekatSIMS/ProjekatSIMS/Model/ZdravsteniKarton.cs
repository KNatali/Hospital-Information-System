using System;
using System.Collections.Generic;

namespace Model
{
   public class ZdravsteniKarton
   {
      public Recept[] recept;
      public System.Collections.ArrayList anamneza;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetAnamneza()
      {
         if (anamneza == null)
            anamneza = new System.Collections.ArrayList();
         return anamneza;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetAnamneza(System.Collections.ArrayList newAnamneza)
      {
         RemoveAllAnamneza();
         foreach (Anamneza oAnamneza in newAnamneza)
            AddAnamneza(oAnamneza);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddAnamneza(Anamneza newAnamneza)
      {
         if (newAnamneza == null)
            return;
         if (this.anamneza == null)
            this.anamneza = new System.Collections.ArrayList();
         if (!this.anamneza.Contains(newAnamneza))
         {
            this.anamneza.Add(newAnamneza);
            newAnamneza.SetZdravsteniKarton(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveAnamneza(Anamneza oldAnamneza)
      {
         if (oldAnamneza == null)
            return;
         if (this.anamneza != null)
            if (this.anamneza.Contains(oldAnamneza))
            {
               this.anamneza.Remove(oldAnamneza);
               oldAnamneza.SetZdravsteniKarton((ZdravsteniKarton)null);
            }
      }
      
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
      public Pacijent pacijent;
   
      private List<String> Alergeni { get; set; }
      private List<String> Terapija;
   
   }
}
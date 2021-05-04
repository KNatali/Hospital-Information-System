using System;

namespace Model
{
   public class Doktor : Osoba
   {
      public int BrojSlobodnihDana;
      public String RadnoVreme;
      public Specijalizacija Specijalizacija { get; set; }
      
      public System.Collections.ArrayList pregled;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetPregled()
      {
         if (pregled == null)
            pregled = new System.Collections.ArrayList();
         return pregled;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetPregled(System.Collections.ArrayList newPregled)
      {
         RemoveAllPregled();
         foreach (Pregled oPregled in newPregled)
            AddPregled(oPregled);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddPregled(Pregled newPregled)
      {
         if (newPregled == null)
            return;
         if (this.pregled == null)
            this.pregled = new System.Collections.ArrayList();
         if (!this.pregled.Contains(newPregled))
         {
            this.pregled.Add(newPregled);
            newPregled.SetDoktor(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemovePregled(Pregled oldPregled)
      {
         if (oldPregled == null)
            return;
         if (this.pregled != null)
            if (this.pregled.Contains(oldPregled))
            {
               this.pregled.Remove(oldPregled);
               oldPregled.SetDoktor((Doktor)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllPregled()
      {
         if (pregled != null)
         {
            System.Collections.ArrayList tmpPregled = new System.Collections.ArrayList();
            foreach (Pregled oldPregled in pregled)
               tmpPregled.Add(oldPregled);
            pregled.Clear();
            foreach (Pregled oldPregled in tmpPregled)
               oldPregled.SetDoktor((Doktor)null);
            tmpPregled.Clear();
         }
      }
   
   }
}
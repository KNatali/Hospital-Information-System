
using Model.DoktorModel;
using System;

namespace Model.UpravnikModel
{
   public class Prostorija
   {
      public Boolean Obrisi()
      {
            // TODO: implement
            return true;
      }
   
      public String Id { get; set; }
      public int Sprat { get; set; }
      public VrstaProstorije Vrsta { get; set; }

        public System.Collections.ArrayList inventar;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetInventar()
      {
         if (inventar == null)
            inventar = new System.Collections.ArrayList();
         return inventar;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetInventar(System.Collections.ArrayList newInventar)
      {
         RemoveAllInventar();
         foreach (Inventar oInventar in newInventar)
            AddInventar(oInventar);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddInventar(Inventar newInventar)
      {
         if (newInventar == null)
            return;
         if (this.inventar == null)
            this.inventar = new System.Collections.ArrayList();
         if (!this.inventar.Contains(newInventar))
            this.inventar.Add(newInventar);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveInventar(Inventar oldInventar)
      {
         if (oldInventar == null)
            return;
         if (this.inventar != null)
            if (this.inventar.Contains(oldInventar))
               this.inventar.Remove(oldInventar);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllInventar()
      {
         if (inventar != null)
            inventar.Clear();
      }
      public Pregled[] pregled;
   
   }
}
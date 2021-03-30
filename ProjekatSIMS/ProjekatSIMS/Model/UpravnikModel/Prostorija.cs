
using Model.DoktorModel;
using ProjekatSIMS.Model.UpravnikModel;
using System;
using System.Collections;

namespace Model.UpravnikModel
{
   public class Prostorija
   {
      public Boolean Obrisi()
      {
            // TODO: implement
            return true;
      }
   
      public String id { get; set; }
      public int sprat { get; set; }
        public EnumProstorija vrsta { get; set; }

        public System.Collections.ArrayList inventar;
        public Prostorija()
        {

        }
        public Prostorija(String id, int sprat, EnumProstorija vrsta, ArrayList inventar)
        {
            this.id = id;
            this.sprat = sprat;
            this.vrsta = vrsta;
            this.inventar = inventar;
        }
        public Prostorija(String id, int sprat, EnumProstorija vrsta)
        {
            this.id = id;
            this.sprat = sprat;
            this.vrsta = vrsta;
            
        }


        public System.Collections.ArrayList GetInventar()
      {
         if (inventar == null)
            inventar = new System.Collections.ArrayList();
         return inventar;
      }
      
      
      public void SetInventar(System.Collections.ArrayList newInventar)
      {
         RemoveAllInventar();
         foreach (Inventar oInventar in newInventar)
            AddInventar(oInventar);
      }
      
      
      public void AddInventar(Inventar newInventar)
      {
         if (newInventar == null)
            return;
         if (this.inventar == null)
            this.inventar = new System.Collections.ArrayList();
         if (!this.inventar.Contains(newInventar))
            this.inventar.Add(newInventar);
      }
      
      
      public void RemoveInventar(Inventar oldInventar)
      {
         if (oldInventar == null)
            return;
         if (this.inventar != null)
            if (this.inventar.Contains(oldInventar))
               this.inventar.Remove(oldInventar);
      }
      
      
      public void RemoveAllInventar()
      {
         if (inventar != null)
            inventar.Clear();
      }
      public Pregled[] pregled;
   
   }
}
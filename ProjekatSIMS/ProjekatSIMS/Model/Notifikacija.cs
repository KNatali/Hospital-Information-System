using System;

namespace Model
{
   public class Notifikacija
   {
      public String Tekst;
      public DateTime Datum;
      
      public System.Collections.ArrayList osoba;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetOsoba()
      {
         if (osoba == null)
            osoba = new System.Collections.ArrayList();
         return osoba;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetOsoba(System.Collections.ArrayList newOsoba)
      {
         RemoveAllOsoba();
         foreach (Osoba oOsoba in newOsoba)
            AddOsoba(oOsoba);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddOsoba(Osoba newOsoba)
      {
         if (newOsoba == null)
            return;
         if (this.osoba == null)
            this.osoba = new System.Collections.ArrayList();
         if (!this.osoba.Contains(newOsoba))
         {
            this.osoba.Add(newOsoba);
            newOsoba.SetNotifikacija(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveOsoba(Osoba oldOsoba)
      {
         if (oldOsoba == null)
            return;
         if (this.osoba != null)
            if (this.osoba.Contains(oldOsoba))
            {
               this.osoba.Remove(oldOsoba);
               oldOsoba.SetNotifikacija((Notifikacija)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllOsoba()
      {
         if (osoba != null)
         {
            System.Collections.ArrayList tmpOsoba = new System.Collections.ArrayList();
            foreach (Osoba oldOsoba in osoba)
               tmpOsoba.Add(oldOsoba);
            osoba.Clear();
            foreach (Osoba oldOsoba in tmpOsoba)
               oldOsoba.SetNotifikacija((Notifikacija)null);
            tmpOsoba.Clear();
         }
      }
   
   }
}
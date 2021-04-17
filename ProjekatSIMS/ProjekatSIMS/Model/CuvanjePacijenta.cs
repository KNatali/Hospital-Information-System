using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
   public class CuvanjePacijenta
   {
      public CuvanjePacijenta(String l)
      {
        lokacija = l;
      }
      public void Sacuvaj(List<Pacijent> p)
      {
        string newJson = JsonConvert.SerializeObject(p);
        File.WriteAllText(lokacija, newJson);
      }
        public List<Pacijent> DobaviPacijente()
      {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            return pacijenti;
      }
   
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
            this.osoba.Add(newOsoba);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveOsoba(Osoba oldOsoba)
      {
         if (oldOsoba == null)
            return;
         if (this.osoba != null)
            if (this.osoba.Contains(oldOsoba))
               this.osoba.Remove(oldOsoba);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllOsoba()
      {
         if (osoba != null)
            osoba.Clear();
      }
   
      private String lokacija;
      private List<Pacijent> pacijenti;

    }
}
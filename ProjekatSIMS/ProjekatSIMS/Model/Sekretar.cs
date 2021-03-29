using System;

namespace Model
{
   public class Sekretar
   {
      public String Jmbg;
      public String Ime;
      public String Prezime;
      public String BrojTelefona;
      public String Email;
      
      public RegistrovaniKorisnik registrovaniKorisnik;
      public System.Collections.ArrayList pacijent;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetPacijent()
      {
         if (pacijent == null)
            pacijent = new System.Collections.ArrayList();
         return pacijent;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetPacijent(System.Collections.ArrayList newPacijent)
      {
         RemoveAllPacijent();
         foreach (Model.Pacijent oPacijent in newPacijent)
            AddPacijent(oPacijent);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddPacijent(Model.Pacijent newPacijent)
      {
         if (newPacijent == null)
            return;
         if (this.pacijent == null)
            this.pacijent = new System.Collections.ArrayList();
         if (!this.pacijent.Contains(newPacijent))
            this.pacijent.Add(newPacijent);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemovePacijent(Model.Pacijent oldPacijent)
      {
         if (oldPacijent == null)
            return;
         if (this.pacijent != null)
            if (this.pacijent.Contains(oldPacijent))
               this.pacijent.Remove(oldPacijent);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllPacijent()
      {
         if (pacijent != null)
            pacijent.Clear();
      }
   
   }
}
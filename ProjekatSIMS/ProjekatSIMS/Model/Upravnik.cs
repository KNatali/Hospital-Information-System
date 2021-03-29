// File:    Upravnik.cs
// Author:  mzari
// Created: 26 March 2021 18:16:13
// Purpose: Definition of Class Upravnik

using Model.UpravnikModel;
using System;

namespace Model
{
   public class Upravnik
   {
      public String id;
      public String ime;
      public String prezime;
      public DateTime datumRodjenja;
      public String email;
      public String telefon;
      
      public RegistrovaniKorisnik registrovaniKorisnik;
      public System.Collections.ArrayList prostorija;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetProstorija()
      {
         if (prostorija == null)
            prostorija = new System.Collections.ArrayList();
         return prostorija;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetProstorija(System.Collections.ArrayList newProstorija)
      {
         RemoveAllProstorija();
         foreach (Prostorija oProstorija in newProstorija)
            AddProstorija(oProstorija);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddProstorija(Prostorija newProstorija)
      {
         if (newProstorija == null)
            return;
         if (this.prostorija == null)
            this.prostorija = new System.Collections.ArrayList();
         if (!this.prostorija.Contains(newProstorija))
            this.prostorija.Add(newProstorija);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveProstorija(Prostorija oldProstorija)
      {
         if (oldProstorija == null)
            return;
         if (this.prostorija != null)
            if (this.prostorija.Contains(oldProstorija))
               this.prostorija.Remove(oldProstorija);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllProstorija()
      {
         if (prostorija != null)
            prostorija.Clear();
      }
   
   }
}
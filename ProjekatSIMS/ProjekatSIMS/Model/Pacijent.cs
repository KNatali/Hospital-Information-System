// File:    Pacijent.cs
// Author:  mrvic
// Created: 28 March 2021 09:56:35
// Purpose: Definition of Class Pacijent

using System;

namespace Model
{
   public class Pacijent : Osoba
   {
      public Boolean IzmeniInformacije(String ime, String prezime, String email, String brojTelefona, String adresa, String jmbg, DateTime datumRodjenja)
      {
         // TODO: implement
         return true;
      }
      
      public Boolean ObrisiPacijent()
      {
         // TODO: implement
         return true;
      }
   
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
            newPregled.SetPacijent(this);      
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
               oldPregled.SetPacijent((Pacijent)null);
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
               oldPregled.SetPacijent((Pacijent)null);
            tmpPregled.Clear();
         }
      }
      public ZdravsteniKarton zdravsteniKarton { get; set; }

    }
}
// File:    Prostorija.cs
// Author:  mzari
// Created: 26 March 2021 18:14:13
// Purpose: Definition of Class Prostorija

using System;

namespace Model
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
      public VrstaProstorije vrsta { get; set; }
        public bool slobodna { get; set; }
      
      public Pregled[] pregled { get; set; }
      public Inventar[] inventar { get; set; }
   
   }
}
// File:    Prostorija.cs
// Author:  mzari
// Created: 26 March 2021 18:14:13
// Purpose: Definition of Class Prostorija

using System;
using System.Collections;

namespace Model
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
      
      public Pregled[] pregled;
        public Inventar[] Inventar { get; set; }

        
    }
}
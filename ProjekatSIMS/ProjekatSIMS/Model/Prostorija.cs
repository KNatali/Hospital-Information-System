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
   
      public String id;
      public int sprat;
      public VrstaProstorije vrsta;
      
      public Pregled[] pregled;
      public Inventar[] inventar;
   
   }
}
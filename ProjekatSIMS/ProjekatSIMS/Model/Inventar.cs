// File:    Inventar.cs
// Author:  mzari
// Created: 26 March 2021 18:22:58
// Purpose: Definition of Class Inventar

using System;

namespace Model
{
   public class Inventar
   {
      public void RasporediStaticku()
      {
         // TODO: implement
      }
      
      public void RasporediDinamicku()
      {
         // TODO: implement
      }
   
      public int Id { get; set; }
      public int Kolicina { get; set; }
        public String Ime { get; set; }
        public Boolean Staticka { get; set; }

        public Prostorija prostorija { get; set; }

    }
}
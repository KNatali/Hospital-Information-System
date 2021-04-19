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
   
      public int id { get; set; }
      public int kolicina { get; set; }
        public String ime { get; set; }
        public Boolean staticka { get; set; }

        public Prostorija prostorija { get; set; }

    }
}
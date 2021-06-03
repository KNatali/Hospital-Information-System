/***********************************************************************
 * Module:  RegistrovaniKorisnik.cs
 * Author:  nata1
 * Purpose: Definition of the Class RegistrovaniKorisnik
 ***********************************************************************/

using ProjekatSIMS.Model;
using System;

namespace Model
{
   public class RegistrovaniKorisnik
   {
      public Boolean Logovanje()
      {
         // TODO: implement
         return true;
      }
      
      public Boolean Odjvljivanje()
      {
         // TODO: implement
         return true;
      }
   
      public String KorisnickoIme { get; set; }
      public String Lozinka { get; set; }
      public Uloga uloga { get; set; }

    public RegistrovaniKorisnik() { }
    public RegistrovaniKorisnik(String korisnickoIme, String lozinka, Uloga uloga) 
    {
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.uloga = uloga;
    }
    }
}
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

        public RegistrovaniKorisnik()
        {

        }
     
   

        public RegistrovaniKorisnik(string korisnickoIme, string lozinka, Uloga uloga)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            this.uloga = uloga;
        }

      public String KorisnickoIme { get; set; }
      public String Lozinka { get; set; }
      public Uloga uloga { get; set; }

  
    
    }
}
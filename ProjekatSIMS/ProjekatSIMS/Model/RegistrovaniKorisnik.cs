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
     
   
      public String KorisnickoIme;
      public String Lozinka;
      public Uloga uloga;

        public RegistrovaniKorisnik(string korisnickoIme, string lozinka, Uloga uloga)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            this.uloga = uloga;
        }
    }
}
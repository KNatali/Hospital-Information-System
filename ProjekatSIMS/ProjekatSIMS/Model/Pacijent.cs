using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Pacijent : Osoba
    {
        public bool jesteMaliciozanKorisnik = false;
        public int otkazaoPregled = 0;
        public int zakazaoPregled = 0;
        public DateTime datumPrvogZakazivanjaPregleda;
        public int IdKartona { get; set; }
    }

}
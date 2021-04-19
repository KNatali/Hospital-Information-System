﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Model
{
    public class SlobodanTermin

    {

        public DateTime Termin { get; set; }
        public String ImeDoktora { get; set; }
        public String PrezimeDoktora { get; set; }
        public bool Slobodan { get; set; }

        public SlobodanTermin(DateTime termin, String ime, String prezime, bool sl)
        {
            Termin = termin;
            ImeDoktora = ime;
            PrezimeDoktora = prezime;
            Slobodan = sl;
            
        }
        public SlobodanTermin()
        {
            Termin = new DateTime();
            ImeDoktora = "";
            PrezimeDoktora = "";
            Slobodan = true;
        }


    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Model
{
    public class OcenaLekara
    {
        public String ImeLekara { get; set; }
        public String PrezimeLekara { get; set; }
        public String Ocena { get; set; }
        public String Komentar { get; set; }
        public Pacijent pacijent { get; set; }
        public OcenaLekara()
        {

        }
        public OcenaLekara(String ime, String prezime, String ocena, String komentar)
        {
            this.ImeLekara = ime;
            this.PrezimeLekara = prezime;
            this.Ocena = ocena;
            this.Komentar = komentar;
        }


    }
}

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


    }
}

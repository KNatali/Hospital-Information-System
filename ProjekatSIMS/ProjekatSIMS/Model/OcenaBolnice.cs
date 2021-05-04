using Model;
using System;

namespace ProjekatSIMS.Model
{
    public class OcenaBolnice
    {
        public String Ocena { get; set; }
        public String Komentar { get; set; }
        public Pacijent Pacijent { get; set; }

        public OcenaBolnice()
        {
            this.Ocena = "";
            this.Komentar = "";
        }
    }
}

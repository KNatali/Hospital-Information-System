using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class IntervalDatuma
    {
        private DateTime pocetnoVrijeme;
        private DateTime krajnjeVrijeme;

        public IntervalDatuma(DateTime pocetnoVrijeme, DateTime krajnjeVrijeme)
        {
            this.PocetnoVrijeme = pocetnoVrijeme;
            this.KrajnjeVrijeme = krajnjeVrijeme;
        }

        public DateTime PocetnoVrijeme { get => pocetnoVrijeme; set => pocetnoVrijeme = value; }
        public DateTime KrajnjeVrijeme { get => krajnjeVrijeme; set => krajnjeVrijeme = value; }
    }
}

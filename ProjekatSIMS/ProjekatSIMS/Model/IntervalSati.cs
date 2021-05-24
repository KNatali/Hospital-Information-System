using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class IntervalSati
    {
        private int pocetniInterval;
        private int krajnjiInterval;

        public IntervalSati(int pocetniInterval, int krajnjiInterval)
        {
            this.PocetniInterval = pocetniInterval;
            this.KrajnjiInterval = krajnjiInterval;
        }

        public int PocetniInterval { get => pocetniInterval; set => pocetniInterval = value; }
        public int KrajnjiInterval { get => krajnjiInterval; set => krajnjiInterval = value; }
    }
}

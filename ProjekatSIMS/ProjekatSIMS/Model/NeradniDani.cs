using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class NeradniDani
    {
        public String doktor { get; set; }
        public IntervalDatuma interval { get; set; }
        public VrsteNeradnihDana Vrsta { get; set; }
        public NeradniDani()
        {
        }
        
    }
}

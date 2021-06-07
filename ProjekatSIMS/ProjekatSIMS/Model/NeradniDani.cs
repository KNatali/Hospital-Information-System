using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class NeradniDani
    {
        public String doktor { get; set; }
        public DateTime NeradnoOd { get; set; }
        public DateTime NeradnoDo { get; set; }
        public VrsteNeradnihDana Vrsta { get; set; }
        public NeradniDani()
        {
            NeradnoOd = NeradnoOd.Date;
            NeradnoDo = NeradnoDo.Date;
        }
        public NeradniDani(DateTime neradnoOd, DateTime neradnoDo)
        {
            NeradnoOd = neradnoOd.Date;
            NeradnoDo = neradnoDo.Date;
        }
    }
}

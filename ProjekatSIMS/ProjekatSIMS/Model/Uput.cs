using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Uput
    {
        public Uput(Pregled pregled,DateTime datum)
        {
            ZakazanPregled = pregled;
            DatumIzdavanja = datum;
        }
        public Pregled ZakazanPregled { get; set; }
        public DateTime DatumIzdavanja { get; set; }
    }
}

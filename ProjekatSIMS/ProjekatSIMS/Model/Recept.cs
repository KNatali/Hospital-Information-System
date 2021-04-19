using System;

namespace Model
{
    public class Recept
    {
        public String NazivLeka { get; set; }
        public String Kolicina { get; set; }
        public DateTime DatumPropisivanjaLeka { get; set; }
        public String Uputstvo { get; set; }

        public ZdravsteniKarton zdravsteniKarton;

    }
}
using System;
using System.Text.Json.Serialization;

namespace Model
{
    public class Recept
    {
        public String NazivLeka { get; set; }
        public String Kolicina { get; set; }
        [JsonIgnore]
        public DateTime DatumPropisivanjaLeka { get; set; }
        [JsonIgnore]
        public String Uputstvo { get; set; }

        public ZdravsteniKarton zdravsteniKarton { get; set; }

    }
}
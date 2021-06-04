using System;
using System.Text.Json.Serialization;

namespace Model
{
    public class Recept
    {
        public int Id { get; set; }
        public String NazivLeka { get; set; }
        public String Kolicina { get; set; }
        [JsonIgnore]
        public DateTime DatumPropisivanjaLeka { get; set; }
        [JsonIgnore]
        public String Uputstvo { get; set; }

        public int IdKartona { get; set; }

    }
}
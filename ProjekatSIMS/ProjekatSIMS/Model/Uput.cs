using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Uput
    {
        public Uput() { }
        public Uput(int id,int idPregleda,DateTime datum)
        {
            Id = id;
            IdPregleda = idPregleda;
            DatumIzdavanja = datum;
        }
        public int IdPregleda { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int Id { get; set; }
       
    }
}

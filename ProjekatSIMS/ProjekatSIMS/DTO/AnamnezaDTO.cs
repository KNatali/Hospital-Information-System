using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.DTO
{
    public class AnamnezaDTO
    {
        private String opis;
        private DateTime datum;
        private int idKartona;

        public AnamnezaDTO(string opis, DateTime datum, int idKartona)
        {
            this.Opis = opis;
            this.Datum = datum;
            this.IdKartona = idKartona;
        }

        public string Opis { get => opis; set => opis = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public int IdKartona { get => idKartona; set => idKartona = value; }
    }
}

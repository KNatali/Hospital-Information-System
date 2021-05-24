using Model;
using System;

namespace ProjekatSIMS.DTO
{
    public class SlobodniTerminiUputSpecijalistiDTO
    {
        private Doktor izabraniDoktor;
        private IntervalDatuma datumi;
        private IntervalSati sati;

        public SlobodniTerminiUputSpecijalistiDTO(Doktor izabraniDoktor, IntervalDatuma datumi, IntervalSati sati)
        {
            this.IzabraniDoktor = izabraniDoktor;
            this.Datumi = datumi;
            this.Sati = sati;
        }

        public Doktor IzabraniDoktor { get => izabraniDoktor; set => izabraniDoktor = value; }
        public IntervalDatuma Datumi { get => datumi; set => datumi = value; }
        public IntervalSati Sati { get => sati; set => sati = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ProjekatSIMS.DTO
{
    public class ReceptDTO
    {
        private Pacijent pacijent;
        private String nazivLijeka;
        private int trajanjeTerapije;
        private DateTime datumPrveKonzumacije;
        private double sat;
        private double minut;
        private String periodIzmedjuKonzumacija;
        private String kolicinaLijeka;

        public ReceptDTO(Pacijent pacijent,string nazivLijeka, int trajanjeTerapije, DateTime datumPrveKonzumacije, double sat, double minut, string periodIzmedjuKonzumacija, string kolicinaLijeka)
        {
            this.Pacijent = pacijent;
            this.NazivLijeka = nazivLijeka;
            this.TrajanjeTerapije = trajanjeTerapije;
            this.DatumPrveKonzumacije = datumPrveKonzumacije;
            this.Sat = sat;
            this.Minut = minut;
            this.PeriodIzmedjuKonzumacija = periodIzmedjuKonzumacija;
            this.KolicinaLijeka = kolicinaLijeka;
        }
        public Pacijent Pacijent { get => pacijent; set => pacijent = value; }
        public string NazivLijeka { get => nazivLijeka; set => nazivLijeka = value; }
        public int TrajanjeTerapije { get => trajanjeTerapije; set => trajanjeTerapije = value; }
        public DateTime DatumPrveKonzumacije { get => datumPrveKonzumacije; set => datumPrveKonzumacije = value; }
        public double Sat { get => sat; set => sat = value; }
        public double Minut { get => minut; set => minut = value; }
        public string PeriodIzmedjuKonzumacija { get => periodIzmedjuKonzumacija; set => periodIzmedjuKonzumacija = value; }
        public string KolicinaLijeka { get => kolicinaLijeka; set => kolicinaLijeka = value; }
    }
}

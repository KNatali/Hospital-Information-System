using System;

namespace Model
{
    public class IntervalDatuma
    {
        private DateTime pocetnoVrijeme;
        private DateTime krajnjeVrijeme;

        public IntervalDatuma(DateTime pocetnoVrijeme, DateTime krajnjeVrijeme)
        {
            this.PocetnoVrijeme = pocetnoVrijeme;
            this.KrajnjeVrijeme = krajnjeVrijeme;
        }

        public DateTime PocetnoVrijeme { get => pocetnoVrijeme; set => pocetnoVrijeme = value; }
        public DateTime KrajnjeVrijeme { get => krajnjeVrijeme; set => krajnjeVrijeme = value; }

        public bool DaLiSeTerminiPoklapaju(IntervalDatuma termin2)
        {
            DateTime pocetnoVrijeme2 = termin2.PocetnoVrijeme;
            DateTime krajnjeVrijeme2 = termin2.KrajnjeVrijeme;
            return (DateTime.Compare(pocetnoVrijeme, pocetnoVrijeme2) >= 0 && DateTime.Compare(pocetnoVrijeme, krajnjeVrijeme2) < 0 ||
                   DateTime.Compare(krajnjeVrijeme, pocetnoVrijeme2) > 0 && DateTime.Compare(krajnjeVrijeme, krajnjeVrijeme2) <= 0 ||
                   DateTime.Compare(pocetnoVrijeme, pocetnoVrijeme2) <= 0 && DateTime.Compare(krajnjeVrijeme, krajnjeVrijeme2) >= 0);
        }

        public  IntervalDatuma RacunanjeVremenaOkoIntervalaPrije()
        {

            DateTime pocetnoVrijeme2 = pocetnoVrijeme.AddDays(-2);
            DateTime krajnjeVrijeme2 = pocetnoVrijeme.AddDays(-1);
            IntervalDatuma noviInterval = new IntervalDatuma(pocetnoVrijeme2, krajnjeVrijeme2);
            return noviInterval;


        }

        public IntervalDatuma RacunanjeVremenaOkoIntervalaPoslije()
        {
            DateTime pocetnoVrijeme2 =pocetnoVrijeme.AddDays(1);
            DateTime krajnjeVrijeme2 = pocetnoVrijeme.AddDays(2);
            IntervalDatuma noviInterval = new IntervalDatuma(pocetnoVrijeme2, krajnjeVrijeme2);
            return noviInterval;
        }


    }
}
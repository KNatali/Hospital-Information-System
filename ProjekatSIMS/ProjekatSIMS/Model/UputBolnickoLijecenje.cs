using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UputBolnickoLijecenje
    {
        private int id;
        private IntervalDatuma interval;
        private String sobaId;
        private int krevetId;
        private int idKartona;

        public UputBolnickoLijecenje()
        {
           
        }
        public UputBolnickoLijecenje(int id,IntervalDatuma interval, string sobaId, int krevetId,int idKartona)
        {
            this.id = id;
            this.Interval = interval;
            this.SobaId = sobaId;
            this.KrevetId = krevetId;
            this.IdKartona = idKartona;
        }

        public int Id { get => id; set => id = value; }
        public IntervalDatuma Interval { get => interval; set => interval = value; }
        public string SobaId { get => sobaId; set => sobaId = value; }
        public int KrevetId { get => krevetId; set => krevetId = value; }
        public int IdKartona { get => idKartona; set => idKartona = value; }
    }
}

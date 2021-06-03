using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.DTO
{
    public class UputBolnickoLijecenjeDTO
    {
        private IntervalDatuma interval;
        private String sobaId;
        private int krevetId;
        private int idKartona;

        public UputBolnickoLijecenjeDTO(IntervalDatuma interval, string sobaId, int krevetId, int idKartona)
        {
            this.Interval = interval;
            this.SobaId = sobaId;
            this.KrevetId = krevetId;
            this.IdKartona = idKartona;
        }

        public IntervalDatuma Interval { get => interval; set => interval = value; }
        public string SobaId { get => sobaId; set => sobaId = value; }
        public int KrevetId { get => krevetId; set => krevetId = value; }
        public int IdKartona { get => idKartona; set => idKartona = value; }
    }
}

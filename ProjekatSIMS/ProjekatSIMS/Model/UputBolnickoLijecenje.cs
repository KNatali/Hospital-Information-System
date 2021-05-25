using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UputBolnickoLijecenje
    {

        private DateTime intervalPocetak;
        private DateTime intervalKraj;
        private String sobaId;
        private int krevetId;

        public UputBolnickoLijecenje()
        {
           
        }
        public UputBolnickoLijecenje(DateTime intervalPocetak, DateTime intervalKraj, string sobaId, int krevetId)
        {
            this.IntervalPocetak = intervalPocetak;
            this.IntervalKraj = intervalKraj;
            this.SobaId = sobaId;
            this.KrevetId = krevetId;
        }

        public DateTime IntervalPocetak { get => intervalPocetak; set => intervalPocetak = value; }
        public DateTime IntervalKraj { get => intervalKraj; set => intervalKraj = value; }
        public string SobaId { get => sobaId; set => sobaId = value; }
        public int KrevetId { get => krevetId; set => krevetId = value; }
    }
}

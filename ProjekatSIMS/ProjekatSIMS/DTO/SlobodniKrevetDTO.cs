using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.DTO
{
    public class SlobodniKrevetDTO
    {
        private String soba;
        private List<int> kreveti;

        public SlobodniKrevetDTO(String soba, List<int> kreveti)
        {
            this.Soba = soba;
            this.Kreveti = kreveti;
        }

        public String Soba { get => soba; set => soba = value; }
        public List<int> Kreveti { get => kreveti; set => kreveti = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.DTO
{
    public class ModifikacijaInventaraDTO
    {
        private String sala;
        private String inventar;
        private int kolicina;

        public ModifikacijaInventaraDTO(string sala, string inventar, int kolicina)
        {
            this.Sala = sala;
            this.Inventar = inventar;
            this.Kolicina = kolicina;
        }

        public string Sala { get => sala; set => sala = value; }
        public string Inventar { get => inventar; set => inventar = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
    }
}

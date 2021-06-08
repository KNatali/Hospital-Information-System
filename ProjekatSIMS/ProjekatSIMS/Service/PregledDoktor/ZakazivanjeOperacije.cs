using Model;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjekatSIMS.Service
{
    public class ZakazivanjeOperacije: ZakazivanjeService
    {

        public override void DopujavanjePregleda(Pregled pregled)
        {
           pregled.Tip = TipPregleda.Operacija;
           

        }

        public override void IspisivanjePoruke()
        {
            MessageBox.Show("Operaicja je uspjesno zakazana");
        }
    }
}

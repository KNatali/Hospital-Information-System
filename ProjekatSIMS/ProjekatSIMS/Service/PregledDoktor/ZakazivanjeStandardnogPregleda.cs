using Model;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjekatSIMS.Service
{
    public class ZakazivanjeStandardnogPregleda : ZakazivanjeService
    {
        

        public override void DopujavanjePregleda(Pregled pregled)
        {
            pregled.Tip = TipPregleda.Standardni;
           
        }

        public override void IspisivanjePoruke()
        {
            MessageBox.Show("Standardni pregled je uspjesno zakazan");
        }
    
    
    }
}

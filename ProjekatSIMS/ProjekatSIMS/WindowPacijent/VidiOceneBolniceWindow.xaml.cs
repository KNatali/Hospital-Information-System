
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{

    public partial class VidiOceneBolniceWindow : Window
    {
        public List<OcenaBolnice> OceneBolnice
        {
            get;
            set;
        }
        

        public VidiOceneBolniceWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            OceneBolnice = new List<OcenaBolnice>();
            OcenaRepository fajl = new OcenaRepository(@"..\..\..\Fajlovi\OcenaBolnice.txt");
            OceneBolnice = fajl.DobaviSveOceneBolnice();
        }

        
    }
}

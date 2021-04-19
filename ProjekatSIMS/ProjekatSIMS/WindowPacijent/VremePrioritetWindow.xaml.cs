using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class VremePrioritetWindow : Window
    {
        public List<SlobodanTermin> Termini { get; set; }
        
        public VremePrioritetWindow()
        {
            InitializeComponent();
            this.DataContext = this;


            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajl = new SlobodanTerminRepository(@"..\..\Fajlovi\SlobodniTermini.txt");
            Termini = fajl.DobaviSveSlobodneTermine();
            



        }

        
    }
}

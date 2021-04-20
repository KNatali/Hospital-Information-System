using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    //public List<SlobodanTermin> Termini { get; set; }
    public partial class PrioritetDatumSWindow : Window
    {
        public PrioritetDatumSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            /*Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajl = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            Termini = fajl.DobaviSveSlobodneTermine();*/
        }
    }
}

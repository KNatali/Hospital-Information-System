using Model;
using Repository;
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
    public partial class TabelaPacijenataSWindow : Window
    {
        public List<Pacijent> Pacijenti { get; set; }
        public TabelaPacijenataSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\Fajlovi\Pacijent.txt");
            Pacijenti = fajl.DobaviPacijente();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

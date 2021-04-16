using Model;
using Model.DoktorModel;
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

namespace ProjekatSIMS.Model.DoktorModel
{
    /// <summary>
    /// Interaction logic for IzvrsavanjePregleda.xaml
    /// </summary>
    public partial class IzvrsavanjePregleda : Window
    {
        public Pregled pregled;
        public IzvrsavanjePregleda(Pregled p)
        {
            InitializeComponent();
            pregled = p;
            this.DataContext = this;
            Ime.Text = pregled.pacijent.Ime;
            Prezime.Text = pregled.pacijent.Prezime;
            Vrijeme.Text = pregled.Pocetak.ToString();
            Trajanje.Text = pregled.Trajanje.ToString();

        }

        private void ZdravstveniKarton(object sender, RoutedEventArgs e)
        {
            ZdravstveniKarton z = new ZdravstveniKarton(pregled.pacijent);
            z.Show();
        }
    }
}

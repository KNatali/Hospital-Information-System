using Model;
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
        public IzvrsavanjePregleda(Pacijent pacijent)
        {
            InitializeComponent();
            InitializeComponent();
            this.DataContext = this;
            Ime.Text = pacijent.Ime;
            Prezime.Text = pacijent.Prezime;
            Jmbg.Text = pacijent.Jmbg;
            Datum.Text = pacijent.DatumRodjenja.ToString();
            Adresa.Text = pacijent.Adresa;
            Broj.Text = pacijent.BrojTelefona;
        }

        private void IzdajRecept(object sender, RoutedEventArgs e)
        {
            Recept r = new Recept();
            r.Show();
        }
    }
}

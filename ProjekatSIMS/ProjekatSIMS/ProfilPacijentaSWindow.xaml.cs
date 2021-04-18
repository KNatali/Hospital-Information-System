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

namespace ProjekatSIMS
{
    public partial class ProfilPacijentaSWindow : Window
    {
        public List<Pacijent> Pacijenti { get; set; }
        public ProfilPacijentaSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            Pacijenti.Add(p);
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Izmene koje ste uneli su sačuvane.", "OBAVEŠTENJE", MessageBoxButton.OK);
            this.Close();
        }
        private void Lista_alergena(object sender, RoutedEventArgs e)
        {
            ListaAlergenaSWindow la = new ListaAlergenaSWindow();
            la.Show();
        }
    }
}

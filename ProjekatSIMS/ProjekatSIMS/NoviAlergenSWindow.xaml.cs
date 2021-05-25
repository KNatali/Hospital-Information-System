using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository;
using System;
using Controller;
using System.Collections.Generic;
using System.IO;
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
    public partial class NoviAlergenSWindow : Window
    {
        public Pacijent pacijent { get; set; }
        public NoviAlergenSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pacijent = p;
        }
        private void Sacuvaj_alergen(object sender, RoutedEventArgs e)
        {
            ZdravstvenikartonController zdravstvenikartonController = new ZdravstvenikartonController();
            zdravstvenikartonController.kreiranjeAlergena(Naziv.Text, pacijent);
            MessageBox.Show("Alergen je uspešno dodat.");
            this.Close();
        }
        private void Otkazi_dodavanje(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

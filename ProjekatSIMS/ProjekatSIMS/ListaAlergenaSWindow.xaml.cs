using Model;
using Newtonsoft.Json;
using Repository;
using Controller;
using System;
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
    public partial class ListaAlergenaSWindow : Window
    {
        private ZdravstvenikartonController zdravstveniKartonController;
        public List<String> Alergeni { get; set; }
        public Pacijent pacijent { get; set; }
        public ListaAlergenaSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pacijent = p;
            List<String> alergeni = new List<String>();
            Alergeni = new List<String>();
            zdravstveniKartonController = new ZdravstvenikartonController();
            alergeni = zdravstveniKartonController.DobaviSveAlergene(pacijent);
            dataGridAlergeni.ItemsSource = alergeni;
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Novi_alergen(object sender, RoutedEventArgs e)
        {
            this.Close();
            NoviAlergenSWindow na = new NoviAlergenSWindow(pacijent);
            na.Show();
        }
    }
}

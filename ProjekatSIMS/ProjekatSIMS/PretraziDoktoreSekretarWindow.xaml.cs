using Model;
using Controller;
using Repository;
using System;
using Service;
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
    public partial class PretraziDoktoreSekretarWindow : Window
    {
        private DoktorController doktorController;
        public List<Doktor> Doktori { get; set; }
        public Doktor dok { get; set; }
        public PretraziDoktoreSekretarWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Doktori = new List<Doktor>();
            List<Doktor> tabelaDoktora = new List<Doktor>();
            doktorController = new DoktorController();
            tabelaDoktora = doktorController.DobaviSve();
            foreach (Doktor d in tabelaDoktora)
                Doktori.Add(d);
        }

        private void Pretraga(object sender, RoutedEventArgs e)
        {
            VidljivostPolja();
            List<Doktor> refreshTabeleDoktora = new List<Doktor>();
            List<Doktor> pretragaDoktora = new List<Doktor>();
            doktorController = new DoktorController();
            pretragaDoktora = doktorController.DobaviSve();
            foreach (Doktor d in pretragaDoktora)
            {
                if (d.Ime == Ime.Text && d.Prezime == Prezime.Text)
                {
                    refreshTabeleDoktora.Add(d);
                    dok = d;
                }
            }
            dataGridDoktori.ItemsSource = refreshTabeleDoktora;
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Prikaz(object sender, RoutedEventArgs e)
        {
            VidljivostPolja();
            Labela.Visibility = Visibility.Visible;
        }
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Doktor d = (Doktor)dataGridDoktori.SelectedItems[0];
            ProfilDoktoraSWindow pd = new ProfilDoktoraSWindow(d);
            pd.Show();
            this.Close();
        }
        private void VidljivostPolja()
        {
            dataGridDoktori.Visibility = Visibility.Visible;
            Labela.Visibility = Visibility.Visible;
        }
    }
}

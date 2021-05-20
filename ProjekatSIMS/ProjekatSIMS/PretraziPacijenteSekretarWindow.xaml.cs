using Controller;
using Model;
using Newtonsoft.Json;
using Repository;
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
    public partial class PretraziPacijenteSekretarWindow : Window
    {
        private PacijentController pacijentController;
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent pac { get; set; }
        public PretraziPacijenteSekretarWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            List<Pacijent> tabelaPacijenata = new List<Pacijent>();
            pacijentController = new PacijentController();
            tabelaPacijenata = pacijentController.DobaviSve();
            foreach (Pacijent p in tabelaPacijenata)
                Pacijenti.Add(p);
        }
        private void Pretraga(object sender, RoutedEventArgs e)
        {
            VidljivostPolja();
            List<Pacijent> refreshTabelePacijenata = new List<Pacijent>();
            List<Pacijent> pretragaPacijenata = new List<Pacijent>();
            pacijentController = new PacijentController();
            pretragaPacijenata = pacijentController.DobaviSve();
            PretragaPoImePrezimePacijenta(refreshTabelePacijenata, pretragaPacijenata);
            /*foreach (Pacijent p in pretragaPacijenata)
            {
                if (p.Ime == Ime.Text && p.Prezime == Prezime.Text)
                {
                    refreshTabelePacijenata.Add(p);
                    pac = p;
                }
            }*/
            dataGridPacijenti.ItemsSource = refreshTabelePacijenata;
        }

        private void PretragaPoImePrezimePacijenta(List<Pacijent> refreshTabelePacijenata, List<Pacijent> pretragaPacijenata)
        {
            foreach (Pacijent p in pretragaPacijenata)
            {
                ProveraImePrezimePacijenta(refreshTabelePacijenata, p);
            }
        }

        private void ProveraImePrezimePacijenta(List<Pacijent> refreshTabelePacijenata, Pacijent p)
        {
            if (p.Ime == Ime.Text && p.Prezime == Prezime.Text)
            {
                refreshTabelePacijenata.Add(p);
                pac = p;
            }
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Prikaz(object sender, RoutedEventArgs e)
        {
            VidljivostPolja();
            dataGridPacijenti.ItemsSource = Pacijenti;
        }
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(p);
            pp.Show();
            this.Close();
        }
        private void VidljivostPolja()
        {
            dataGridPacijenti.Visibility = Visibility.Visible;
            Labela.Visibility = Visibility.Visible;
        }
    }
}

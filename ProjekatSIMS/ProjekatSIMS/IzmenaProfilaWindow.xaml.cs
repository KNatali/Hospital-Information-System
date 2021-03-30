using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ProjekatSIMS
{
    public partial class IzmenaProfilaWindow : Window
    {
        public List<Pacijent> Pacijenti { get; private set; }

        public IzmenaProfilaWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            Pacijenti.Add(p);
        }
        private void Prekini_izmenu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li ste sigurni?", "Provera", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Potvrdi_izmene(object sender, RoutedEventArgs e)
        {
            Pacijent p = (Pacijent)dataGrid.SelectedItems[0];
            String jmbg = Jmbg.Text;
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String telefon = Telefon.Text;
            String mail = Mail.Text;
            String adresa = Adresa.Text;
            DateTime datum = (DateTime)Datum.SelectedDate;
            String linija;
            using (StreamReader fajl = new StreamReader(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt"))
            {
                while ((linija = fajl.ReadLine()) != null)
                {
                    string[] deo = linija.Split(",");
                }
                fajl.Close();
            }
        
            MessageBoxResult ret = MessageBox.Show("Da li ste sigurni?", "Provera", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    if (p.IzmeniInformacije() == true)
                    {
                        MessageBox.Show("Pacijent je izmenjen.", "Obavestenje");
                        this.Close();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

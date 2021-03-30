using Model;
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
    public partial class IzmenaProfilaWindow : Window
    {
        public IzmenaProfilaWindow()
        {
            InitializeComponent();
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
            String jmbg = Jmbg.Text;
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String telefon = Telefon.Text;
            String mail = Mail.Text;
            String adresa = Adresa.Text;
            DateTime datum = (DateTime)Datum.SelectedDate;
            Pacijent p = new Pacijent();
            String red = System.Environment.NewLine + "" + ime + "," + prezime + "," + mail + "," + telefon + "," + adresa + "," + jmbg + "," + datum;

            using StreamWriter fajl = new StreamWriter(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt", true);
            fajl.WriteLineAsync(red);
            MessageBoxResult ret = MessageBox.Show("Prikazi izmenjene podatke u tabeli?", "Uspesno izmenjeni podaci pacijenta", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    TabelaPacijenata tp = new TabelaPacijenata();
                    tp.Show();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

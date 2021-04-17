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
    /// <summary>
    /// Interaction logic for IzmenaPregledaSWindow.xaml
    /// </summary>
    public partial class IzmenaPregledaSWindow : Window
    {
        public IzmenaPregledaSWindow()
        {
            InitializeComponent();
            /*this.DataContext = this;

            Pregledi = new List<Pregled>();
            Pregledi.Add(p);
            Pregled = p;
            Pocetak.SelectedDate = Pregled.Pocetak;
            Trajanje.Text = Pregled.Pocetak.Hour.ToString();
            Tip.Text = Pregled.Pocetak.Minute.ToString();*/
        }
        public List<Pregled> Pregledi { get; }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Uspešno ste izmenili termin. " +
                "Poslato je obaveštenje pacijentu i doktoru.", "OBAVEŠTENJE", MessageBoxButton.OK);
            this.Close();
        }
    }
}

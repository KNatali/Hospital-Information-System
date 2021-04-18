using Model;
using Repository;
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
    public partial class IzmenaPregledaSWindow : Window
    {
        public PregledRepository fajl { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public Pregled pre { get; set; }
        public IzmenaPregledaSWindow(Pregled p)
        {
            InitializeComponent();
            this.DataContext = this;
            Pregledi = new List<Pregled>();
            Datum.SelectedDate = p.Pocetak;
            Sat.Text = p.Pocetak.Hour.ToString();
            Minut.Text = p.Pocetak.Minute.ToString();
            Trajanje.Text = p.Trajanje.ToString();

            /*List<Pregled> ListaPregleda = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\SviPregledi");
            ListaPregleda = fajl.GetListaPregledaSekretar();*/
            
            /*Pregledi.Add(p);
            Pre = p;
            Pocetak.SelectedDate = Pregled.Pocetak;
            Trajanje.Text = Pregled.Pocetak.Hour.ToString();
            Tip.Text = Pregled.Pocetak.Minute.ToString();*/
        }

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

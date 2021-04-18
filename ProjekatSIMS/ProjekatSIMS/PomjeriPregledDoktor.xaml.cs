using Controller;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PomjeriPregledDoktor.xaml
    /// </summary>
    public partial class PomjeriPregledDoktor : Page
    {

        public PregledController pregledController = new PregledController();
        public Pregled pregled { get; set; }
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PomjeriPregledDoktor(Pregled p)
        {
            InitializeComponent();
            this.DataContext = this;


            Pregledi = new List<Pregled>();
            pregled = new Pregled();
            Pregledi.Add(p);
            pregled = p;
            Date.SelectedDate = pregled.Pocetak;
            Sati.Text = pregled.Pocetak.Hour.ToString();
            Minuti.Text = pregled.Pocetak.Minute.ToString();
           
        }

        private void PotvrdiIzmjenu(object sender, RoutedEventArgs e)
        {
            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti); //izabrano vrijeme
            DateTime datum2 = datum1.AddMinutes(pregled.Trajanje);
            if(pregledController.IzmjenaPregledaDoktor(pregled, datum1))
            {
                MessageBox.Show("Uspjesno ste izmjenili termin pregleda");
            }
            else
                MessageBox.Show("Neuspjesna promjena termina pregleda");
           
            
            
            this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));
          

        }


    }
}

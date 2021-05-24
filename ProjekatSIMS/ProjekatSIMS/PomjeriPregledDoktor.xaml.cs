using Controller;
using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{

    public partial class PomjeriPregledDoktor : Page
    {

        public PregledController pregledController = new PregledController();
        public PregledRepository pregledRepository = new PregledRepository();
        private ZauzetostTerminaPregledaController pomjeriPregledDoktorController = new ZauzetostTerminaPregledaController();
        private PrikazSlobodnihTerminaController prikazSlobodnihTerminaController = new PrikazSlobodnihTerminaController();
        private IzmjenaPregledaDoktorController izmjenaPregledaDoktorController = new IzmjenaPregledaDoktorController();
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
            DateTime datum1;
            double sat;
            double minut;

            if (Termin.Visibility == Visibility.Visible)
            {
                sat = Convert.ToDouble(Termin.Text.Split(":")[0]);
                minut = Convert.ToDouble(Termin.Text.Split(":")[1]);
            }
            else
            {
                sat = Convert.ToDouble(Sati.Text);
                minut = Convert.ToDouble(Minuti.Text);
            }
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut); //izabrano vrijeme
            DateTime datum2 = datum1.AddMinutes(pregled.Trajanje);
            IntervalDatuma termin = new IntervalDatuma(datum1, datum2);

            PomjeranjePregleda(datum1, termin);
        }

        private void PomjeranjePregleda(DateTime datum1, IntervalDatuma termin)
        {
            if (pomjeriPregledDoktorController.PomjeriPregled(pregled, termin))
            {
                List<String> termini = new List<String>();
                termini = prikazSlobodnihTerminaController.PrikazTermina(pregled, termin);
                MessageBox.Show("Dati termin je zauzet");
                Termin.Visibility = Visibility.Visible;
                Izbor.Visibility = Visibility.Visible;
                Termin.ItemsSource = termini;
            }
            else
            {
                izmjenaPregledaDoktorController.IzmjeniPregled(pregled, datum1);
                MessageBox.Show("Uspjesno je izmjenjen termin");
                this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));

            }
        }



    }
}

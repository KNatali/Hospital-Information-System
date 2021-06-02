using Controller;
using Model;
using System;
using System.Collections.Generic;

using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;


namespace ProjekatSIMS.WindowPacijent
{
    public partial class ZakaziPregled : Page
    {
        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
        public int MAKSIMAMLNO_OTKAZIVANJA = 10;
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent trenutniPacijent { get; set; }
        public ZakaziPregled(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;

        }
        private void Zakazi_Pregled(object sender, RoutedEventArgs e)
        {
            
            Pregled p = new Pregled();
            String ime = trenutniPacijent.Ime;
            String prezime = trenutniPacijent.Prezime;
            String imeDoktora = ImeDoktora.Text;
            String prezimeDoktora = PrezimeDoktora.Text;
            String jmbg = trenutniPacijent.Jmbg;
            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum1 = new DateTime();

            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);
            int trajanje = 30;
            DateTime datum2 = datum1.AddMinutes(trajanje);

            PregledController pregCont = new PregledController();

            if (pregCont.ZakazivanjePregledaPacijent(ime, prezime, imeDoktora, prezimeDoktora, datum1, jmbg) == true)
            {
                MessageBox.Show("Pregled je uspesno zakazan!");
                //this.NavigationService.Navigate(new Uri("VidiWindow.xaml", UriKind.Relative));
            }
            else if (pregCont.DaLiJeTerminZauzet() == true)
            {
                if (DoktorPrioritet.IsChecked == true)
                {
                    DoktorPrioritetWindow dpw = new DoktorPrioritetWindow(imeDoktora, prezimeDoktora, ime, prezime);
                    dpw.Show();
                }
                else
                {
                    VremePrioritetWindow vpw = new VremePrioritetWindow(datum1, ime, prezime);
                    vpw.Show();
                }
            }
            else
            {
                MessageBox.Show("Pregled nije zakazan.");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DoktorPrioritet.IsChecked == true)
            {
                MessageBox.Show("Odabrali ste doktora kao prioritet u slucaju da Vas termin nije slobodan.");
                prioritetDoktor = 1;
            }
            else if (VremePrioritet.IsChecked == true)
            {
                MessageBox.Show("Odabrali ste vreme kao prioritet u slucaju da Vas doktor nije slobodan.");
                prioritetVreme = 1;
            }

        }
        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            DoktorPrioritet.Foreground = Brushes.Blue;
            VremePrioritet.Foreground = Brushes.Blue;

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using Controller;
using Model;
using System;
using System.Collections.Generic;

using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using ProjekatSIMS.Controller.PregledPacijent;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class ZakaziPregled : Page
    {
        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
        public int MAKSIMAMLNO_OTKAZIVANJA = 10;
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent trenutniPacijent { get; set; }
        public ZakazivanjePregledaController zakazivanjePregledaController = new ZakazivanjePregledaController();
        public ZakaziPregled(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;

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

            if (zakazivanjePregledaController.ZakazivanjePregledaPacijent(imeDoktora, prezimeDoktora, datum1, trenutniPacijent) == true)
            {
                MessageBox.Show("Pregled je uspesno zakazan!");
                PocetnaPacijent pocetna = new PocetnaPacijent(trenutniPacijent);
                this.NavigationService.Navigate(pocetna);
            }
            else if (zakazivanjePregledaController.DaLiJeTerminZauzet(datum1) == true)
            {
                if (prioritetDoktor == 1)
                {
                    DoktorPrioritetWindow dp = new DoktorPrioritetWindow(imeDoktora, prezimeDoktora, trenutniPacijent);
                    dp.Show();
                }
                else if(prioritetVreme == 1)
                {
                    VremePrioritetWindow vp = new VremePrioritetWindow(datum1, trenutniPacijent);
                    vp.Show();
                }
            }
            else
            {
                MessageBox.Show("Pregled nije zakazan.");
                PocetnaPacijent pocetna = new PocetnaPacijent(trenutniPacijent);
                this.NavigationService.Navigate(pocetna);

            }
            
        }

      
        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            DoktorPrioritet.Foreground = Brushes.Blue;
            VremePrioritet.Foreground = Brushes.Blue;

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pocetna = new PocetnaPacijent(trenutniPacijent);
            this.NavigationService.Navigate(pocetna);
        }
    }
}

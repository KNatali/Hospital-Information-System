using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Controller.PregledPacijent;
using ProjekatSIMS.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class IzmeniPregledPacijenta : Page
    {
        public BrojacOtkazivanjaController brojacOtkazivanjaController = new BrojacOtkazivanjaController();
        public IzmenaPregledaController izmenaPregledaController = new IzmenaPregledaController();
        public List<Pregled> Pregledi { get; set; }
        public List<Pregled> PreglediSvi { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
        
        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
        public Pacijent trenutniPacijent { get; set; }
        public Pregled p { get; set; }
        public IzmeniPregledPacijenta(Pacijent pacijent)
        {
            
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;

            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            PreglediSvi = fajl.DobaviSvePregledePacijent();
            Pregledi = fajl.DobaviPregledeZaPacijenta(trenutniPacijent);

            Pacijenti = new List<Pacijent>();
            PacijentRepository file = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            Pacijenti = file.DobaviSve();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
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

        private void Izaberi_Click(object sender, RoutedEventArgs e)
        {
           p = (Pregled)dataGridPregledi.SelectedItems[0];
           
        }

        public void PrioritetProzor(DateTime datumNovi, String imeDoktora,String prezimeDoktora)
        {
            if (izmenaPregledaController.ProveraZauzetostiTermina(datumNovi) == 1)
            {
                if (prioritetVreme == 1)
                {
                    VremePrioritetWindow vp = new VremePrioritetWindow(datumNovi, trenutniPacijent);
                    vp.Show();
                }
                else if (prioritetDoktor == 1)
                {
                    DoktorPrioritetWindow dp = new DoktorPrioritetWindow(imeDoktora, prezimeDoktora, trenutniPacijent);
                    dp.Show();

                }
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum = (DateTime)Datum.SelectedDate;
            DateTime datumNovi = new DateTime();
            datumNovi = datum.AddHours(sati);
            datumNovi = datumNovi.AddMinutes(minuti);
            String imeDoktora = ImeDoktora.Text;
            String prezimeDoktora = PrezimeDoktora.Text;

            brojacOtkazivanjaController.BrojacOtkazivanjaPregleda(trenutniPacijent);
            if(izmenaPregledaController.IzmeniPregled(datumNovi, p) == true)
            {
                PrioritetProzor(datumNovi,imeDoktora,prezimeDoktora);

            }else 
            {
                PreglediSvi.Remove(p);
                Doktor doktor = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
                p = new Pregled { Pocetak = datumNovi, doktor = doktor, pacijent = trenutniPacijent };

                PreglediSvi.Add(p);
                string newJson = JsonConvert.SerializeObject(PreglediSvi);
                File.WriteAllText(@"..\..\..\Fajlovi\Pregled.txt", newJson);
                MessageBox.Show("Pregled je uspesno izmenjen.");
            }
            string newJ = JsonConvert.SerializeObject(Pacijenti);
            File.WriteAllText(@"..\..\..\Fajlovi\Pacijent.txt", newJ);
            IzmeniPregledPacijenta ip = new IzmeniPregledPacijenta(trenutniPacijent);
            this.NavigationService.Navigate(ip);

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pocetna = new PocetnaPacijent(trenutniPacijent);
            this.NavigationService.Navigate(pocetna);
        }
    }
}

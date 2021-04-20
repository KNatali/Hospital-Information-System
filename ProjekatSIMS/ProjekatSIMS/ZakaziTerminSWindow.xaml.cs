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
    public partial class ZakaziTerminSWindow : Window
    {
        public ZakaziTerminSWindow()
        {
            InitializeComponent();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            String jmbgp = Jmbg_pacijent.Text;
            String jmbgd = Jmbg_doktor.Text;
            DateTime datum = (DateTime)Datum.SelectedDate;
            double sati = Convert.ToDouble(Sat.Text);
            double minuti = Convert.ToDouble(Minut.Text);
            DateTime datum1 = new DateTime();

            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);
            int trajanje = 30;
            DateTime datum2 = datum1.AddMinutes(trajanje);

            p.Tip = TipPregleda.Standardni;
            p.Pocetak = datum1;
            p.Trajanje = trajanje;
            Pacijent pac = new Pacijent { Jmbg = jmbgp };
            p.pacijent = pac;
            Doktor dr = new Doktor { Jmbg = jmbgd };
            p.doktor = dr;
            p.StatusPregleda = StatusPregleda.Zakazan;


            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.GetListaPregledaSekretar();

            ProstorijaRepository file = new ProstorijaRepository(@"..\..\..\Fajlovi\Prostorija.txt");
            List<Prostorija> prostorije = file.DobaviSveProstorije();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.slobodna == true)
                {
                    p.prostorija = pr;
                    pr.slobodna = false;
                    break;
                }
            }

            pregledi.Add(p);

            fajl.SacuvajPregledSekretar(pregledi);

            MessageBox.Show("Termin je uspešno zakazan. Poslato je obaveštenje pacijentu i doktoru.", "OBAVEŠTENJE", MessageBoxButton.OK);
            this.Close();
        }
    }
}

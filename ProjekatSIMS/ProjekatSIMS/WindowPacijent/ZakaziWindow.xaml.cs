using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{

    public partial class ZakaziWindow : Window
    {
        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
        public ZakaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String imeDoktora = ImeDoktora.Text;
            String prezimeDoktora = PrezimeDoktora.Text;
            String jmbg = Jmbg.Text;
            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum1 = new DateTime();

            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);
            int trajanje = 30;
            DateTime datum2 = datum1.AddMinutes(trajanje);

            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.DobaviSvePregledePacijent();

            int zauzetPregledFlag = 0;

            foreach (Pregled preg in pregledi)
            {
                if ((preg.Pocetak) == datum1)
                {
                    MessageBox.Show("Odabrali ste termin koji je zauzet, na osnovu Vaseg prioriteta cemo Vam predloziti slobodne termine.");
                    zauzetPregledFlag = 1;
                    break;
                }
            }
            if (zauzetPregledFlag == 0)
            {
                p.Tip = TipPregleda.Standardni;
                p.Pocetak = datum1;
                p.Trajanje = trajanje;
                Pacijent pac = new Pacijent { Jmbg = jmbg, Ime = ime, Prezime = prezime };
                p.pacijent = pac;
                Doktor dr = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
                p.doktor = dr;
                p.StatusPregleda = StatusPregleda.Zakazan;

                ProstorijaRepository file = new ProstorijaRepository(@"..\..\Fajlovi\Prostorija.txt");
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

                fajl.SacuvajPregledPacijent(pregledi);

                MessageBox.Show("Pregled je uspesno zakazan.");

                this.Close();
            }
            else if (zauzetPregledFlag == 1)
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



        }

        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            DoktorPrioritet.Foreground = Brushes.Blue;
            VremePrioritet.Foreground = Brushes.Blue;

        }
    }
}

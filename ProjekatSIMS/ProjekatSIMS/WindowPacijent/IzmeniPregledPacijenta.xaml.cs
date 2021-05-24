using Model;
using Newtonsoft.Json;
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
        public IzmenaPregledaService izmenaPregledaService = new IzmenaPregledaService();
        public List<Pregled> Pregledi { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
        
        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
        public IzmeniPregledPacijenta()
        {
            
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();

            Pacijenti = new List<Pacijent>();
            PacijentRepository file = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            Pacijenti = file.DobaviSve();
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0]; //pregled koji je izabran za izmenu

            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum = (DateTime)Datum.SelectedDate;
            DateTime datumNovi = new DateTime();
            datumNovi = datum.AddHours(sati);
            datumNovi = datumNovi.AddMinutes(minuti);
            String imeDoktora = ImeDoktora.Text;
            String prezimeDoktora = PrezimeDoktora.Text;

            izmenaPregledaService.BrojacOtkazivanjaPregleda(p.pacijent.Ime, p.pacijent.Prezime);

            string newJ = JsonConvert.SerializeObject(Pacijenti);
            File.WriteAllText(@"..\..\..\Fajlovi\Pacijent.txt", newJ);


            int slobodanTerminFlag = 0;


            if ((p.Pocetak.AddHours(24) > datumNovi))
            {
                MessageBox.Show("Pregled se moze izmeniti najmanje 24h pre zakazanog termina!");
            }
            else if (p.Pocetak.AddHours(48) <= datumNovi)
            {
                MessageBox.Show("Pregled se moze pomeriti najvise za dva dana unapred.");
            }
            else
            {
                foreach (Pregled pregled in Pregledi)
                {
                    if (pregled.Pocetak == datumNovi)
                    {
                        MessageBox.Show("Ovaj termin je zauzet. Ponudicemo Vam novi termin spram Vaseg prioriteta.");
                        slobodanTerminFlag = 1;
                        if (prioritetVreme == 1)
                        {
                            VremePrioritetWindow vpw = new VremePrioritetWindow(datumNovi, p.pacijent.Ime, p.pacijent.Prezime);
                            vpw.Show();
                        }
                        else if (prioritetDoktor == 1)
                        {
                            DoktorPrioritetWindow dpw = new DoktorPrioritetWindow(imeDoktora, prezimeDoktora, p.pacijent.Ime, p.pacijent.Prezime);
                            dpw.Show();
                        }

                        break;
                    }

                }

                if (slobodanTerminFlag == 0)
                {
                    Pregledi.Remove(p);
                    Doktor doktor = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
                    p = new Pregled { Pocetak = datumNovi, doktor = doktor, };
                    Pregledi.Add(p);
                    string newJson = JsonConvert.SerializeObject(Pregledi);
                    File.WriteAllText(@"..\..\..\Fajlovi\Pregled.txt", newJson);
                    MessageBox.Show("Pregled je uspesno izmenjen.");
                }
            }
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

    }
}

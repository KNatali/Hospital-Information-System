using Model;
using Newtonsoft.Json;
using ProjekatSIMS.WindowPacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace ProjekatSIMS
{

    public partial class IzmeniWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
       
        public IzmeniWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();

          
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (DoktorPrioritet.IsChecked == true) {
                MessageBox.Show("Odabrali ste doktora kao prioritet u slucaju da Vas termin nije slobodan.");
                prioritetDoktor = 1;
            } 
            else if (VremePrioritet.IsChecked == true) {
                MessageBox.Show("Odabrali ste vreme kao prioritet u slucaju da Vas doktor nije slobodan.");
                prioritetVreme = 1;
            }
                
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0]; //pregled koji je izabran za izmenu

            //preuzimanje datuma i vremena iz forme

            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum = (DateTime)Datum.SelectedDate;
            DateTime datumNovi = new DateTime();
            datumNovi = datum.AddHours(sati);
            datumNovi = datumNovi.AddMinutes(minuti);
            String imeDoktora = ImeDoktora.Text;
            
            String prezimeDoktora = PrezimeDoktora.Text;
            
            

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
                foreach(Pregled pregled in Pregledi)
                {
                    if (pregled.Pocetak == datumNovi)
                    {
                        MessageBox.Show("Ovaj termin je zauzet. Ponudicemo Vam novi termin spram Vaseg prioriteta.");
                        slobodanTerminFlag = 1;
                        if(prioritetVreme == 1)
                        {
                            VremePrioritetWindow vpw = new VremePrioritetWindow();
                            vpw.Show();
                        }else if(prioritetDoktor == 1)
                        {
                            DoktorPrioritetWindow dpw = new DoktorPrioritetWindow();
                            dpw.Show();
                        }
                        
                        break;
                    }
                    
                }

                if(slobodanTerminFlag == 0)
                {
                    Pregledi.Remove(p);
                    p.Pocetak = datumNovi;
                    Doktor doktor = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
                    p.doktor = doktor;
                    Pregledi.Add(p);

                    string newJson = JsonConvert.SerializeObject(Pregledi);
                    File.WriteAllText(@"..\..\..\Fajlovi\Pregled.txt", newJson);
                    MessageBox.Show("Pregled je uspesno izmenjen.");
                }
                

            }


            this.Close();

        }

        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            DoktorPrioritet.Foreground = Brushes.Blue;
            VremePrioritet.Foreground = Brushes.Blue;

        }
        


    }
}

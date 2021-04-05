using Model.DoktorModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.Model.DoktorModel
{

    public partial class PrikazPromjena : Window
    {
        public Pregled Pregled { get; set; }
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazPromjena(Pregled pregled)
        {
            InitializeComponent();
            this.DataContext = this;


            Pregledi = new List<Pregled>();

            Pregledi.Add(pregled);
            Pregled = pregled;
            Date.SelectedDate = Pregled.Pocetak;
            Sati.Text = Pregled.Pocetak.Hour.ToString();
            Minuti.Text = Pregled.Pocetak.Minute.ToString();
            Trajanje.Text = Pregled.Trajanje.ToString();



        }

        private void PotvrdiIzmjenu(object sender, RoutedEventArgs e)
        {
           // Pregled p = (Pregled)dataGrid.SelectedItems[0];


            //prikupljam polja iz forme


            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti); //izabrano vrijeme
            int trajanje = Convert.ToInt32(Trajanje.Text);
            DateTime datum2 = datum1.AddMinutes(trajanje);

            //opet gledam da li je termin zauzet

            /*String line1;
            using (StreamReader file = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt"))
            {

                while ((line1 = file.ReadLine()) != null)
                {
                    string[] parts = line1.Split(",");
                    DateTime datum11 = Convert.ToDateTime(parts[3]);
                    DateTime datum22 = datum11.AddMinutes(Convert.ToDouble(parts[4]));
                   

                    if (parts[6] == "Zakazan")
                    {
                        //ako je pocetk zakazanog termina unutar nekog drugog termina
                        if (DateTime.Compare(datum1, datum11) > 0 && DateTime.Compare(datum1, datum22) < 0
                            || DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) < 0
                            || DateTime.Compare(datum1, datum11) == 0
                            || DateTime.Compare(datum1, datum11) < 0 && DateTime.Compare(datum2, datum22) > 0)
                        {

                            MessageBox.Show("Termin je zauzet");
                            return;
                        }
                    }
                }

                file.Close();
            }*/

            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.UcitajSvePreglede();
            foreach (Pregled pr in pregledi)
            {
                if (pr.Id == Pregled.Id)
                {
                    pr.Pocetak = datum1;
                    pr.Trajanje = trajanje;
                    break;
                }
            }
            fajl.Sacuvaj(pregledi);


            MessageBox.Show("Pregled je uspjesno izmjenjen");
            this.Close();




        }
    }
}

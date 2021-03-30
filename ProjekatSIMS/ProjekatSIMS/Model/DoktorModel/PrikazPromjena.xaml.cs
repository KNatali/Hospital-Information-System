using Model.DoktorModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS.Model.DoktorModel
{
  
    public partial class PrikazPromjena : Window
    {

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
            
        }

        private void PotvrdiIzmjenu(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGrid.SelectedItems[0];
           

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

            String line1;
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
            }

            if (p.PomjeriPregledDoktor(datum1,trajanje) == true)
            {

                MessageBox.Show("Pregled je uspjesno izmjenjen");
                this.Close();
                

            }


        }
    }
}

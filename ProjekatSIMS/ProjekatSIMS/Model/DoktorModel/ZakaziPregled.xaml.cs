using Model.DoktorModel;
using Model.UpravnikModel;
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
    /// <summary>
    /// Interaction logic for ZakaziPregled.xaml
    /// </summary>
    public partial class ZakaziPregled : Window
    {
        public ZakaziPregled()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            //prikupljam polja iz forme
           
            String jmbg = Jmbg.Text;
            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum1 = new DateTime();
            datum1=datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);
            int trajanje = Convert.ToInt32(Trajanje.Text);
            DateTime datum2 = datum1.AddMinutes(trajanje);
        
            String idSale = Sala.Text;  //!!!!!DODAJ
            TipPregleda t = new TipPregleda();
            Pregled p = new Pregled();

            if (Btn1.IsChecked == true)
                p.Tip = TipPregleda.Standardni;
            else
                p.Tip = TipPregleda.Operacija;

            String tip = p.Tip.ToString();

           

            //gledam da li postoji dati pacijent

            
            int znak = 0;
            String line = "";

            using (StreamReader file = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pacijent.txt"))
            {

                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");

                    if (parts[5] == jmbg)
                    {
                        znak++;
                        break;
                    }
                }

                file.Close();
            }
            if (znak == 0)
            {
                MessageBox.Show("Pacijent nije nadjen. Pokusajte ponovo!");
                return;
                
            }


            //sada gledam da li je vrijeme okej tj da li se poklapa sa nekim
            String line1;
            String id=""; //id pregleda
          
            using (StreamReader file = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt"))
            {

                while ((line1 = file.ReadLine()) != null)
                {
                    string[] parts = line1.Split(",");
                    DateTime datum11 = Convert.ToDateTime(parts[3]);
                    DateTime datum22 = datum11.AddMinutes(Convert.ToDouble(parts[4]));
                    id = parts[0];

                    if (parts[6] =="Zakazan")
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
            int Idnovi = Convert.ToInt32(id)+1;
            //stavljam sve u red kako bi bilo u fajlu
            String red =Idnovi.ToString()+ "," + jmbg + "," + "1511990855023" + "," + datum1.ToString() + "," + trajanje.ToString() +
                "," + tip + "," + "Zakazan";



            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt");
             fajl.Sacuvaj(red,true);

             MessageBox.Show("Uspjesno je zakazan termin");
            this.Close();
        }
    }
}

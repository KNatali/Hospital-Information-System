using Model;
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

namespace ProjekatSIMS.Model.PacijentModel
{
    /// <summary>
    /// Interaction logic for ZakaziWindow.xaml
    /// </summary>
    public partial class ZakaziWindow : Window
    {
        public ZakaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ZakaziPregled (object sender, RoutedEventArgs e)
        {
            string line;

            //uzimanje polja iz forme
 
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String jmbg = Jmbg.Text;
            String imedoktora = ImeDoktora.Text;
            String prezimedoktora = PrezimeDoktora.Text;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum = (DateTime)Date.SelectedDate;
            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);
            int trajanje = 30;
            DateTime datum2 = datum1.AddMinutes(trajanje);

             
            Pregled p = new Pregled();
            p.Tip = TipPregleda.Standardni;
            String tip = p.Tip.ToString();
            String linija;
            int brojac = 0;
            using (StreamReader file = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Doktor.txt"))
            {
                while((linija = file.ReadLine()) != null)
                {
                    string[] parts = linija.Split(",");
                    if(parts[1] == imedoktora)
                    {
                        if(parts[2] == prezimedoktora)
                        {
                            brojac++;
                            break;
                        }
                    }
                }
                file.Close();
            }



            //ako je pronasao doktora upisuje termin
            if (brojac > 0)
            {
                String red = "3" + "," + ime + "," + prezime + "," + jmbg + "," + datum1.ToString() + "," + trajanje.ToString() + "," + tip + "," + "Zakazan" + "," + imedoktora + "," + prezimedoktora;

                using StreamWriter fajl = new StreamWriter(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt", true);
                fajl.WriteLineAsync(red);

                MessageBox.Show(red);
            }
            else
            {
                MessageBox.Show("Ne postoji doktor sa tim imenom, unesite ime postojece ime doktora!");            
            }










        }
    }
    

}

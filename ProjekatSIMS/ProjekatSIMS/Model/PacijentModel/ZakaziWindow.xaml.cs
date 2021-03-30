using Model.DoktorModel;
using System;
using System.IO;
using System.Windows;

namespace ProjekatSIMS.Model.PacijentModel
{

    public partial class ZakaziWindow : Window
    {
        public ZakaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
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
            String jednaLinija;
            int brojac = 0;
            String jmbgdoktora = "";
            int id_counter = 150;
            String jedanRed;
            String sala = "";
            String linijaRed;

            using (StreamReader file = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Doktor.txt"))
            {
                while ((linija = file.ReadLine()) != null)
                {

                    string[] parts = linija.Split(",");
                    if (parts[1] == imedoktora)
                    {
                        if (parts[2] == prezimedoktora)
                        {
                            brojac++;
                            jmbgdoktora = parts[0];
                            break;
                        }
                    }
                }
                file.Close();
            }

            using (StreamReader fjl = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt"))
            {
                while ((jednaLinija = fjl.ReadLine()) != null)
                {
                    string[] delovi = jednaLinija.Split(",");

                    
                    DateTime datum11 = Convert.ToDateTime(delovi[3]);
                    DateTime datum12 = datum11.AddMinutes(Convert.ToDouble(delovi[4]));
                    if (delovi[6] == "Zakazan")
                    {
                        if (DateTime.Compare(datum1, datum11) > 0 && DateTime.Compare(datum1, datum12) < 0
                            || DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum12) < 0
                            || DateTime.Compare(datum1, datum11) == 0
                            || DateTime.Compare(datum1, datum11) < 0 && DateTime.Compare(datum2, datum12) > 0
                            )
                        {
                            MessageBox.Show("Termin je zauzet. Izaberite drugi termin");
                            return;
                        }
                    }

                }
                fjl.Close();
            }
            using (StreamReader dokument = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt"))
            {
                while ((jedanRed = dokument.ReadLine()) != null)
                {
                    id_counter++;

                }
                dokument.Close();
            }

            using (StreamReader dok = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Sala.txt"))
            {
                while ((linijaRed = dok.ReadLine()) != null)
                {
                    string[] deo = linijaRed.Split(",");
                    //zauzima prvu slobodnu salu
                    if (deo[2] == "sala")
                    {
                        if (deo[3] == "false")
                        {
                            sala = deo[1];
                            break;
                        }

                    }
                }
                dok.Close();
            }


            //ako je pronasao doktora upisuje termin
            if (brojac > 0)
            {

                String red = id_counter + "," + jmbg + "," + jmbgdoktora + "," + datum1.ToString() + "," + trajanje.ToString() + "," + tip + "," + "Zakazan" + "," + sala;


                using StreamWriter fajl = new StreamWriter(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt", true);
                fajl.WriteLineAsync(red);
                ;

                MessageBox.Show(red);
            }
            else
            {
                MessageBox.Show("Ne postoji doktor sa tim imenom, unesite postojece ime doktora!");
            }
            this.Close();
            










        }

       
    }


}

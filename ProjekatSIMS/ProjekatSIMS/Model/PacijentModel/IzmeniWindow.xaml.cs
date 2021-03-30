using Model.DoktorModel;
using Model.PacijentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ProjekatSIMS.Model.PacijentModel
{

    public partial class IzmeniWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public IzmeniWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt");
            Pregledi = fajl.DobaviSve();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0]; //pregled koji je izabran za izmenu

            string line;
            List<String> lines = new List<string>();
            //preuzimanje datuma i vremena iz forme

            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum = (DateTime)Datum.SelectedDate;
            DateTime datumNovi = new DateTime();
            datumNovi = datum.AddHours(sati);
            datumNovi = datumNovi.AddMinutes(minuti);
            DateTime datumNoviTrajanje = new DateTime();
            datumNoviTrajanje = datumNovi.AddMinutes(30);
            string jmbgNovi = "";
            string jmbgDoktorNovi = "";
            int idNovi;
            double trajanjeNovo;
            string tipNovi = "";
            string statusNovi = "";
            string salaNova = "";
            string red = "";


            using (StreamReader fajl = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt"))
            {
                while((line = fajl.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");
                        if(parts[0] != p.Id.ToString())
                    {
                        lines.Add(line);
                    }
                    else
                    {
                        idNovi = Convert.ToInt32( parts[0]);
                        jmbgNovi = parts[1];
                        jmbgDoktorNovi = parts[2];
                        trajanjeNovo = Convert.ToDouble(parts[4]);
                        tipNovi = parts[5];
                        statusNovi = parts[6];
                        salaNova = parts[7];

                        red = idNovi + "," + jmbgNovi + "," + jmbgDoktorNovi + "," + datumNovi.ToString() + "," + trajanjeNovo.ToString() + "," + tipNovi + "," + statusNovi + "," + salaNova;
                        lines.Add(red);
                    }

                    DateTime datum11 = Convert.ToDateTime(parts[3]);
                    DateTime datum12 = datum11.AddMinutes(Convert.ToDouble(parts[4]));
                    if (parts[6] == "Zakazan")
                    {
                        if (DateTime.Compare(datumNovi, datum11) > 0 && DateTime.Compare(datumNovi, datum12) < 0
                            || DateTime.Compare(datumNoviTrajanje, datum11) > 0 && DateTime.Compare(datumNoviTrajanje, datum12) < 0
                            || DateTime.Compare(datumNovi, datum11) == 0
                            || DateTime.Compare(datumNovi, datum11) < 0 && DateTime.Compare(datumNoviTrajanje, datum12) > 0
                            )
                        {
                            MessageBox.Show("Termin je zauzet. Izaberite drugi termin");
                            return;
                        }
                    }
                }

                fajl.Close();
            }
            File.WriteAllLinesAsync(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt", lines);
            MessageBox.Show("Pregled je uspesno izmenjen.");
            this.Close();

        }
    }
}

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

    public partial class PrikazPregleda : Window
    {
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazPregleda()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"C: \Users\nata1\Projekat\ProjekatSIMS\Pregled.txt");
            Pregledi = fajl.UcitajSvePreglede();
        }

        private void OtkaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];


            string line;
            List<String> lines = new List<string>();

            using (StreamReader file = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt"))
            {

                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");
                    if (parts[0] != p.Id.ToString())
                    {
                        lines.Add(line);
                    }
                }       

                file.Close();
            }

             File.WriteAllLinesAsync(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt", lines);
            MessageBox.Show("Pregled je uspjesno otkazan");
            this.Close();
        }

        private void IzmijeniPregled(object sender, RoutedEventArgs e)
        {

        }
    }
}

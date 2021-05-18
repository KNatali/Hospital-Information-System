using Newtonsoft.Json;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS.WindowPacijent
{
    
    public partial class PregledPodsetnika : Page
    {
        public List<Podsetnik> Podsetnici
        {
            get;
            set;
        }
        public PregledPodsetnika()
        {
            InitializeComponent();
            this.DataContext = this;
            Podsetnici = new List<Podsetnik>();
            PodsetnikRepository fajl = new PodsetnikRepository(@"..\..\..\Fajlovi\Podsetnik.txt");
            Podsetnici = fajl.DobaviSvePodsetnikeZaPacijenta("Biljana","Marinkov");

        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            PodsetnikRepository fajl = new PodsetnikRepository(@"..\..\..\Fajlovi\Podsetnik.txt");
            Podsetnik odabrani = (Podsetnik)dataGridPodsetnik.SelectedItems[0];
            Podsetnici = fajl.DobaviSvePodsetnikeZaPacijenta(odabrani.pacijent.Ime, odabrani.pacijent.Prezime);
            string naziv;
            string opis;
            naziv = odabrani.nazivPodsetika;
            opis = odabrani.opisPodsetnika;
            using (StreamReader file = new StreamReader(@"..\..\..\Fajlovi\Podsetnik.txt"))
            {

                Podsetnici.Remove(odabrani);

            }
            string newJson = JsonConvert.SerializeObject(Podsetnici);
            File.WriteAllText(@"..\..\..\Fajlovi\Podsetnik.txt", newJson);
            MessageBox.Show("Podsetnik je obrisan");
        }
    }
}

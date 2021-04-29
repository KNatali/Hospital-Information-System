using Model;
using Newtonsoft.Json;
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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for EvidencijaLIjekova.xaml
    /// </summary>
    public partial class EvidencijaLIjekova : Page
    {

        public List<Lijek> SviLijekovi { get; set; }
        public List<Lijek> LijekoviNaCekanju { get; set; }
        public EvidencijaLIjekova()
        {
            InitializeComponent();
            this.DataContext = this;
          
            PrikazTabele();
        }

        public void PrikazTabele()
        {
            SviLijekovi = new List<Lijek>();
            LijekoviNaCekanju = new List<Lijek>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Lijek.txt"))
            {
                string json = r.ReadToEnd();
                SviLijekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);
            }
            foreach (Lijek l in SviLijekovi)
            {
                if (l.Status == OdobravanjeLekaEnum.Ceka)
                    LijekoviNaCekanju.Add(l);
            }

            dataGridVerifikacija.ItemsSource = LijekoviNaCekanju;
        }



        private void PrikaziDetaljaLijeka(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
            Opis.Text = lijek.Opis;
            List<String> sastojci = lijek.Alergeni;
            Sastojci.ItemsSource = sastojci;
        }

        private void PregledVerifikovanihLijekova(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("VerifikovaniLijekoviDoktor.xaml", UriKind.Relative));
        }

        private void IzmijeniLijek(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
            IzmjenaLijekDoktor i = new IzmjenaLijekDoktor(lijek);
            this.NavigationService.Navigate(i);
        }

        private void PrihvatiLijek(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
            List<Lijek> lijekoviNovi = new List<Lijek>();

            //cuvanje u fajl izmjenjeni lijek
            SviLijekovi.Find(p => p.NazivLeka ==lijek.NazivLeka).Status =OdobravanjeLekaEnum.Odobren ;

            string newJson = JsonConvert.SerializeObject(SviLijekovi);
            File.WriteAllText(@"..\..\..\Fajlovi\Lijek.txt", newJson);



            PrikazTabele();
        }

        private void OdbaciLijek(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
            List<Lijek> lijekoviNovi = new List<Lijek>();

            //cuvanje u fajl izmjenjeni lijek
            SviLijekovi.Find(p => p.NazivLeka == lijek.NazivLeka).Status = OdobravanjeLekaEnum.Odbijen;

            string newJson = JsonConvert.SerializeObject(SviLijekovi);
            File.WriteAllText(@"..\..\..\Fajlovi\Lijek.txt", newJson);

          
            //da se pozdaina zatamni
            this.Opacity = 0.3;
            OdbacivanjePoruka o = new OdbacivanjePoruka();
            o.ShowDialog();
            
            this.Opacity = 1;
            //PORUKU TREBA NEGDJE SMJESTITI
           // MessageBox.Show(o.Poruka);

            PrikazTabele();
        }

        
    }
}

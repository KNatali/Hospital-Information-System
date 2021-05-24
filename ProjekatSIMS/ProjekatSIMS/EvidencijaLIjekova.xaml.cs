using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Model;
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

    public partial class EvidencijaLIjekova : Page
    {
        private PrikazEvidencijeLijekovaController prikazEvidencijeLijekovaController = new PrikazEvidencijeLijekovaController();
        private VerifikovanjeLijekovaController verifikovanjeLijekovaController = new VerifikovanjeLijekovaController();
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
            TipLijekaPremaPrikazu tip = TipLijekaPremaPrikazu.Neverifikovan;
            LijekoviNaCekanju = prikazEvidencijeLijekovaController.PrikazLijekovaPoStatusu(tip);
           /*using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Lijek.txt"))
            {
                string json = r.ReadToEnd();
                SviLijekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);
            }
            foreach (Lijek l in SviLijekovi)
            {
                if (l.Status == OdobravanjeLekaEnum.Ceka)
                    LijekoviNaCekanju.Add(l);
            }*/

            dataGridVerifikacija.ItemsSource = LijekoviNaCekanju;
        }



        private void PrikazDetaljaLijeka(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
            Opis.Text = lijek.Opis;
            List<String> sastojci = lijek.Alergeni;
            List<String> alternativni = lijek.AlternativniLekovi;
            Sastojci.ItemsSource = sastojci;
            AlternativniLijekovi.ItemsSource = alternativni;


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
            Lijek izabraniLijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
            verifikovanjeLijekovaController.OdobriLijek(izabraniLijek);
          /*  List<Lijek> lijekoviNovi = new List<Lijek>();

            //cuvanje u fajl izmjenjeni lijek
            SviLijekovi.Find(p => p.NazivLeka ==lijek.NazivLeka).Status =OdobravanjeLekaEnum.Odobren ;

            string newJson = JsonConvert.SerializeObject(SviLijekovi);
            File.WriteAllText(@"..\..\..\Fajlovi\Lijek.txt", newJson);*/

            PrikazTabele();
        }

        private void OdbaciLijek(object sender, RoutedEventArgs e)
        {
            Lijek izabraniLijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
         
            this.Opacity = 0.3;
            OdbacivanjePoruka porukaProzor = new OdbacivanjePoruka();
            porukaProzor.ShowDialog();
            this.Opacity = 1;

            verifikovanjeLijekovaController.OdbaciLijek(izabraniLijek, porukaProzor.Poruka);
            PrikazTabele();

            //cuvanje u fajl izmjenjeni lijek
            /* SviLijekovi.Find(p => p.NazivLeka == lijek.NazivLeka).Status = OdobravanjeLekaEnum.Odbijen;
             SviLijekovi.Find(p => p.NazivLeka == lijek.NazivLeka).PorukaOdbaci =o.Poruka;

             string newJson = JsonConvert.SerializeObject(SviLijekovi);
             File.WriteAllText(@"..\..\..\Fajlovi\Lijek.txt", newJson);*/



        }

        
    }
}

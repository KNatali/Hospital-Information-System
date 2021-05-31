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

    public partial class VerifikovaniLIjekoviDoktor : Page
    {
        private PrikazEvidencijeLijekovaController prikazEvidencijeLijekovaController = new PrikazEvidencijeLijekovaController();
        private VerifikovanjeLijekovaController verifikovanjeLijekovaController = new VerifikovanjeLijekovaController();
        public List<Lijek> SviLijekovi { get; set; }
        public List<Lijek> VerifikovaniLijekovi { get; set; }
        public VerifikovaniLIjekoviDoktor()
        {
            InitializeComponent();
        
            this.DataContext = this;
          
            SviLijekovi = new List<Lijek>();
            VerifikovaniLijekovi = new List<Lijek>();
            TipLijekaPremaPrikazu tip = TipLijekaPremaPrikazu.Verifikovan;
            VerifikovaniLijekovi = prikazEvidencijeLijekovaController.PrikazLijekovaPoStatusu(tip);


            ListCollectionView collectionView = new ListCollectionView(VerifikovaniLijekovi);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Status"));


            dataGridVerifikovani.ItemsSource = collectionView;
        }

        private void PrikaziDetaljaLijeka(object sender, RoutedEventArgs e)
        {

            Poruka.Visibility = Visibility.Hidden;
            Lijek lijek = (Lijek)dataGridVerifikovani.SelectedItems[0];
            Opis.Text = lijek.Opis;
            List<String> sastojci = lijek.Alergeni;
            List<String> alternativni = lijek.AlternativniLekovi;
            Sastojci.ItemsSource = sastojci;
            AlternativniLijekovi.ItemsSource = alternativni;


            if (lijek.PorukaOdbaci !=null)
            {
               Poruka.Visibility = Visibility.Visible;
               Poruka1.Text = lijek.PorukaOdbaci;
            }

        }



        private void IzmijeniLijek(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikovani.SelectedItems[0];
            //IzmjenaLijekDoktor i = new IzmjenaLijekDoktor(lijek);
            // this.NavigationService.Navigate(i);
        }


        private void NazadNaVerifikovane(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("EvidencijaLijekova.xaml", UriKind.Relative));
        }
    }

    

}

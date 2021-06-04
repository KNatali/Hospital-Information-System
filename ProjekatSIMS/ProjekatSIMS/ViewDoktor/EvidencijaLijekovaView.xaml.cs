using Controller;
using Model;
using ProjekatSIMS.ViewModelDoktor;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.ViewDoktor
{

    public partial class EvidencijaLijekovaView : Page
    {
        private PrikazEvidencijeLijekovaController prikazEvidencijeLijekovaController = new PrikazEvidencijeLijekovaController();
        private VerifikovanjeLijekovaController verifikovanjeLijekovaController = new VerifikovanjeLijekovaController();
        public List<Lijek> SviLijekovi { get; set; }
        public List<Lijek> LijekoviNaCekanju { get; set; }
        private TipLijekaPremaPrikazu tip;
        public EvidencijaLijekovaView(EvidencijaLijekovaViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;


        }

        private void dataGridVerifikacija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /* public void PrikazTabele()
         {
             SviLijekovi = new List<Lijek>();
             LijekoviNaCekanju = new List<Lijek>();
             TipLijekaPremaPrikazu tip = TipLijekaPremaPrikazu.Neverifikovan;
             LijekoviNaCekanju = prikazEvidencijeLijekovaController.PrikazLijekovaPoStatusu(tip);
             dataGridVerifikacija.ItemsSource = LijekoviNaCekanju;
         }

         */
        /* private void PregledVerifikovanihLijekova(object sender, RoutedEventArgs e)
         {
             this.NavigationService.Navigate(new Uri("VerifikovaniLijekoviDoktor.xaml", UriKind.Relative));
         }

         private void IzmijeniLijek(object sender, RoutedEventArgs e)
         {
             Lijek lijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
            // IzmjenaLijekDoktor i = new IzmjenaLijekDoktor(lijek);
             //this.NavigationService.Navigate(i);
         }
        */
        /*  private void PrihvatiLijek(object sender, RoutedEventArgs e)
          {
              Lijek izabraniLijek = (Lijek)dataGridVerifikacija.SelectedItems[0];
              verifikovanjeLijekovaController.OdobriLijek(izabraniLijek);
              PrikazTabele();
          }*/

        /* private void OdbaciLijek(object sender, RoutedEventArgs e)
         {
             Lijek izabraniLijek = (Lijek)dataGridVerifikacija.SelectedItems[0];

             this.Opacity = 0.3;
             OdbacivanjePoruka porukaProzor = new OdbacivanjePoruka();
             porukaProzor.ShowDialog();
             this.Opacity = 1;

             verifikovanjeLijekovaController.OdbaciLijek(izabraniLijek, porukaProzor.Poruka);
             PrikazTabele();

         }
        */

    }
}

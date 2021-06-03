using System;
using System.Collections.Generic;
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

namespace ProjekatSIMS.UpravnikWindows
{
   
    public partial class Upravnik : Window
    {
        private NavigationService NavigationService { get; set; }
        public ResizeMode ResizeMode { get; set; }
        public Upravnik()
        {
            InitializeComponent();

            this.ResizeMode = ResizeMode.CanResizeWithGrip;
        }
        private void PocetnaStranica(object sender, RoutedEventArgs e)
        {

        }
        //Renoviranje
        private void Renoviranje(object sender, RoutedEventArgs e)
        {
           // UpravnikFrame.Content = new RenoviranjeUpravnik();
        }
        private void NaprednoRenoviranje(object sender, RoutedEventArgs e)
        {
            //UpravnikFrame.Content = new RenoviranjeUpravnik();
        }


        //Pomoc
        private void Pomoc(object sender, RoutedEventArgs e)
        {

        }

        //Lekovi
        private void PregledajLekove(object sender, RoutedEventArgs e)
        {
            //pretraga
           // UpravnikFrame.Content = new PregledLekovaUpravnik();
        }
        private void IzmeniLek(object sender, RoutedEventArgs e)
        {

            //UpravnikFrame.Content = new IzmenaLekaUpravnik();
        }
        private void KreirajLek(object sender, RoutedEventArgs e)
        {

           // UpravnikFrame.Content = new PregledProstorijaUpravnik();
        }

        // Prostorije
        private void PregledajProstorije(object sender, RoutedEventArgs e)
        {

            UpravnikFrame.Content = new PregledProstorija();
            //omoguci pretragu
        }
        private void IzmeniProstoriju(object sender, RoutedEventArgs e)
        {

            UpravnikFrame.Content = new IzmeniProstoriju();
            //odraditi validaciju
        }
        private void KreirajProstoriju(object sender, RoutedEventArgs e)
        {
            //odraditi validaciju
           // UpravnikFrame.Content = new PregledProstorijaUpravnik();
        }
        // Inventar
        private void PregledajInventar(object sender, RoutedEventArgs e)
        {
            //omoguci pretragu
           // UpravnikFrame.Content = new PregledInventaraUpravnik();
        }
        private void DinamickiInventar(object sender, RoutedEventArgs e)
        {
            //omoguci pretragu
           // UpravnikFrame.Content = new PregledDinamickogInventara();
        }
        private void KreirajDinamicki(object sender, RoutedEventArgs e)
        {

           // UpravnikFrame.Content = new PregledProstorijaUpravnik();
        }
        private void KreirajStaticki(object sender, RoutedEventArgs e)
        {

           // UpravnikFrame.Content = new PregledProstorijaUpravnik();
        }
        private void IzmeniInventar(object sender, RoutedEventArgs e)
        {

           // UpravnikFrame.Content = new PregledProstorijaUpravnik();
        }

        private void UpravnikFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}

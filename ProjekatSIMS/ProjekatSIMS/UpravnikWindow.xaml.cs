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

namespace ProjekatSIMS
{
    
    public partial class UpravnikWindow : Window
    {

        private NavigationService NavigationService { get; set; }
        public UpravnikWindow()
        {
            InitializeComponent();
        }

        

        private void Inventar(object sender, RoutedEventArgs e)
        {
            UpravnikFrame.Content = new PregledInventaraUpravnik();
        }
        private void Lekovi(object sender, RoutedEventArgs e)
        {
            UpravnikFrame.Content = new PregledLekovaUpravnik();
        }

        private void PocetnaStranica(object sender, RoutedEventArgs e)
        {

        }
        private void Prostorije(object sender, RoutedEventArgs e)
        {
            UpravnikFrame.Content = new PregledProstorijaUpravnik();

        }
        private void Renoviranje(object sender, RoutedEventArgs e)
        {
            UpravnikFrame.Content = new RenoviranjeUpravnik();
        }
        private void Pomoc(object sender, RoutedEventArgs e)
        {

        }
    }
}

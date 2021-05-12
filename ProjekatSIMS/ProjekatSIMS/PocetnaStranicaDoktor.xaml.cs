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
    /// <summary>
    /// Interaction logic for PocetnaStranicaDoktor.xaml
    /// </summary>
    public partial class PocetnaStranicaDoktor : Page
    {
        public PocetnaStranicaDoktor()
        {
            InitializeComponent();
           
            
        }

        private void PrikazLijekova(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("EvidencijaLijekova.xaml", UriKind.Relative));


        }
    }
}

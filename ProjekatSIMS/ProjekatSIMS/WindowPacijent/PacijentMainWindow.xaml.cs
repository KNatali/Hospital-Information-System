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

namespace ProjekatSIMS.WindowPacijent
{
    public partial class PacijentMainWindow : Window
    {
        private NavigationService NavigationService { get; set; }

        public PacijentMainWindow()
        {
            InitializeComponent();
            
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new ZakaziPregled();
        }

        private void VidiPreglede(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new VidiPreglede();
        }
    }
}

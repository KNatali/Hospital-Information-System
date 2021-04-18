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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for DoktorWindow.xaml
    /// </summary>
    public partial class DoktorWindow : Window
    {
        private NavigationService NavigationService { get; set; }

        public DoktorWindow()
        {
            InitializeComponent();
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new ZakaziPregledDoktor();

        }

        private void ZakaziOperaciju(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new ZakaziOperacijuDoktor();

        }

        private void PrikazPregleda(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new PrikazPregledaDoktor();

        }

        private void PretraziPacijenta(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new PretragaPacijentaDoktor();
 

        }
    }
}

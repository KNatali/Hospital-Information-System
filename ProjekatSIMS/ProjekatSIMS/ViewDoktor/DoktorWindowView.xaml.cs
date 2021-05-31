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
using ProjekatSIMS.ViewModelDoktor;

namespace ProjekatSIMS.ViewDoktor
{
    
    public partial class DoktorWindowView : Window
    {
        private DoktorWindowViewModel viewModel;
        private NavigationService NavigationService { get; set; }
        public DoktorWindowViewModel _ViewModel
        {
            get { return viewModel; }
            set
            {
                viewModel = value;
            }
        }

        public DoktorWindowView()
        {

            InitializeComponent();
            this.viewModel = new DoktorWindowViewModel(this.DoktorFrame.NavigationService);
            this.DataContext = this.viewModel;


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
            // DoktorFrame.Content = new PrikazPregledaDoktor();

        }
        private void PrikazZavrsenihPregleda(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new PrikazZavrsenihPregleda();

        }

        private void PretraziPacijenta(object sender, RoutedEventArgs e)
        {
            // DoktorFrame.Content = new PretragaPacijentaDoktor();


        }

        private void PocetnaStranica(object sender, RoutedEventArgs e)
        {
            // DoktorFrame.Content = new PocetnaStranicaDoktorView();


        }

        private void MojProfil(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new ZakaziPregledDoktor();

        }

        private void Odjavljivanje(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new ZakaziPregledDoktor();

        }

        private void Pomoc(object sender, RoutedEventArgs e)
        {
            DoktorFrame.Content = new ZakaziPregledDoktor();

        }


    }
}

using Model;
using Repository;
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
    /// Interaction logic for IzvrsavanjePregledaDoktor.xaml
    /// </summary>
    public partial class IzvrsavanjePregledaDoktor : Page
    {
        public Pregled pregled;
        public IzvrsavanjePregledaDoktor(Pregled p)
        {
            InitializeComponent();
            pregled = p;
            this.DataContext = this;
            Ime.Text = pregled.pacijent.Ime;
            Prezime.Text = pregled.pacijent.Prezime;
            Vrijeme.Text = pregled.Pocetak.ToString();
            Trajanje.Text = pregled.Trajanje.ToString();
            Tip.Text = pregled.Tip.ToString();
        }

        private void ZdravstveniKarton(object sender, RoutedEventArgs e)
        {
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pregled.pacijent);
            // this.NavigationService.Navigate(new Uri("ZdravstveniKartonDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(z);
        }

        private void ZavrsiPregled(object sender, RoutedEventArgs e)
        {
            pregledRepository = new PregledRepository();
            
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledeDoktor();
            foreach (Pregled pr in pregledi)
            {
                if (pr.Id == pregled.Id)
                {
                    pr.StatusPregleda= StatusPregleda.Zavrsen;

                    break;
                }
            }
            pregledRepository.SacuvajPregledDoktor(pregledi);
            this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));

        }

        private void IzdavanjeUputa(object sender, RoutedEventArgs e)
        {
            IzdavanjeUputaDoktor z = new IzdavanjeUputaDoktor();
            // this.NavigationService.Navigate(new Uri("ZdravstveniKartonDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(z);
        }

        public PregledRepository pregledRepository;
    }


}

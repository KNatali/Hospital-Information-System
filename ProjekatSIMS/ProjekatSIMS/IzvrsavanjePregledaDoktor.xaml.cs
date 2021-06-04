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

    public partial class IzvrsavanjePregledaDoktor : Page
    {
        public Pregled pregled;
        private PacijentRepository pacijentRepository = new PacijentRepository();
        public Pacijent Pacijent{get; set;}
        public IzvrsavanjePregledaDoktor(Pregled p)
        {
            InitializeComponent();
            pregled = p;
            Pacijent = p.pacijent;
           // Pacijent = pacijentRepository.DobaviById(p.Pacijent);
            this.DataContext = this;
           
        }

        private void ZdravstveniKarton(object sender, RoutedEventArgs e)
        {
            //ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pregled.Pacijent);
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pregled.pacijent);


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
            pregledRepository.SacuvajPregledeDoktor(pregledi);
            this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));

        }

        private void IzdavanjeUputa(object sender, RoutedEventArgs e)
        {
            IzdavanjeUputaSpecijalistiDoktor z = new IzdavanjeUputaSpecijalistiDoktor(Pacijent);
           
            this.NavigationService.Navigate(z);
        }
        private void IzdavanjeUputaBolnickoLijecenje(object sender, RoutedEventArgs e)
        {
            UputZaBolnickoLijecenjeDoktor z = new UputZaBolnickoLijecenjeDoktor(Pacijent);
        
            this.NavigationService.Navigate(z);
        }

        private void IzdavanjeRecepta(object sender, RoutedEventArgs e)
        {
            IzdajReceptDoktor z = new IzdajReceptDoktor(Pacijent);
        
            this.NavigationService.Navigate(z);
        }

        private void KreiranjeAnamneze(object sender, RoutedEventArgs e)
        {
            KreirajAnamnezu z = new KreirajAnamnezu(Pacijent);
      
            this.NavigationService.Navigate(z);
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        public PregledRepository pregledRepository;
    }


}

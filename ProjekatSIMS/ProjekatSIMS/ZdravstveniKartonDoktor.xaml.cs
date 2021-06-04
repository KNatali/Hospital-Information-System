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
  
    public partial class ZdravstveniKartonDoktor : Page
    {
        public Pacijent Pacijent { get; set; }
        private PacijentRepository pacijentRepository = new PacijentRepository();
        public ZdravstveniKartonDoktor(Pacijent pacijent)
        {
            InitializeComponent();
          
            this.DataContext = this;

            //Pacijent = pacijentRepository.DobaviById(idPacijenta);
            Pacijent = pacijent;
            Jmbg.Text = Pacijent.Jmbg;
            Ime.Text = Pacijent.Ime;
            Prezime.Text = Pacijent.Prezime;
            Datum.Text = Pacijent.DatumRodjenja.ToString();
            Email.Text = Pacijent.Email;
            Broj.Text = Pacijent.BrojTelefona;
            Adresa.Text = Pacijent.Adresa;
            
        }

        private void KreiranjeAnamneze(object sender, RoutedEventArgs e)
        {
            KreirajAnamnezu an = new KreirajAnamnezu(Pacijent);
           
            this.NavigationService.Navigate(an);
        }

        private void PrikazAnamneza(object sender, RoutedEventArgs e)
        {
            PrikazAnamneza a = new PrikazAnamneza(Pacijent);

            this.NavigationService.Navigate(a);
        }

        private void PrikazUputa(object sender, RoutedEventArgs e)
        {
            PrikazUputaZaBolnickoLijecenje a = new PrikazUputaZaBolnickoLijecenje(Pacijent);

            this.NavigationService.Navigate(a);
        }
        private void IzdavanjeRecepta(object sender, RoutedEventArgs e)
        {
           IzdajReceptDoktor a = new IzdajReceptDoktor(Pacijent);

            this.NavigationService.Navigate(a);
        }

        private void PrikazRecepata(object sender, RoutedEventArgs e)
        {
            PrikazRecepataDoktor a = new PrikazRecepataDoktor(Pacijent);

            this.NavigationService.Navigate(a);
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {

            this.NavigationService.GoBack();
        }
    }
}

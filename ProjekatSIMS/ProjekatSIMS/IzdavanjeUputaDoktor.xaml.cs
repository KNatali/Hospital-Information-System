using Controller;
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

    public partial class IzdavanjeUputaDoktor : Page
    {
        private OsobaRepository osobaRepository = new OsobaRepository((@"..\..\..\Fajlovi\Doktor.txt"));
        private PregledController pregledController = new PregledController();
        private Doktor odabraniDoktor = new Doktor();
        private List<Doktor> sviDoktori = new List<Doktor>();
        private List<Doktor> doktoriPrikaz;
        private Pacijent izabraniPacijent;

        public IzdavanjeUputaDoktor(Pacijent pacijent )
        {
            InitializeComponent();
            this.DataContext = this;
            izabraniPacijent = pacijent;
            sviDoktori = osobaRepository.DobaviDoktore();
            var specijalizacije = Enum.GetValues(typeof(Specijalizacija));
            Specijalizacije.ItemsSource = specijalizacije;
           
        }

        private void DoktoriOdabraneSpecijalizacije(object sender, RoutedEventArgs e)
        {
            Specijalizacija odabranaSpecijalizacija =(Specijalizacija) Specijalizacije.SelectedItem;
            doktoriPrikaz = new List<Doktor>();
            foreach(Doktor d in sviDoktori)
            {
                if (odabranaSpecijalizacija == d.Specijalizacija)
               
                     doktoriPrikaz.Add(d);
            }
           Doktori.ItemsSource =doktoriPrikaz;
        }

        private void PrikazSlobodnihTermina(object sender, RoutedEventArgs e)
        {
            Doktor izabraniDoktor = (Doktor)Doktori.SelectedItem;
            DateTime pocetnoVrijeme = (DateTime)DatumPocetak.SelectedDate;
            DateTime krajnjeVrijeme = (DateTime)DatumKraj.SelectedDate;
            int pocetniInterval = Convert.ToInt32(IntervalPocetak.Text);
            int krajnjiInterval = Convert.ToInt32(IntervalKraj.Text);


            List<DateTime> slobodniTermini = new List<DateTime>();
            slobodniTermini=pregledController.PrikazSlobodnihTermina(izabraniDoktor, pocetnoVrijeme, krajnjeVrijeme,pocetniInterval,krajnjiInterval);
            Termini.ItemsSource = slobodniTermini;
        }

        private void IzdavanjeUputa(object sender, RoutedEventArgs e)
        {
            Doktor izabraniDoktor = (Doktor)Doktori.SelectedItem;
            DateTime izabranTermin = (DateTime)Termini.SelectedItem;

            if (pregledController.IzdavanjeUputa(izabraniPacijent, izabraniDoktor, izabranTermin))
            {
                MessageBox.Show("Uput je uspjesno izdat");
                this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));
            }
            else
                MessageBox.Show("Neuspjesno izdavanje uputa");

        }
    }
}

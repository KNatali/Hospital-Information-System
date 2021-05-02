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
    /// Interaction logic for IzdavanjeUputaDoktor.xaml
    /// </summary>
    public partial class IzdavanjeUputaDoktor : Page
    {
        OsobaRepository osobaRepository = new OsobaRepository((@"..\..\..\Fajlovi\Doktor.txt"));
        Doktor odabraniDoktor = new Doktor();
        private List<Doktor> sviDoktori = new List<Doktor>();
        public IzdavanjeUputaDoktor()
        {
            InitializeComponent();
            this.DataContext = this;
            //ono sto ide u combo box za specijalizaciju
            List<Doktor> doktori = new List<Doktor>();
            sviDoktori = osobaRepository.DobaviDoktore();
            //rucno pravim
            List<String> specijalizacije = new List<String>();
            specijalizacije.Add("Opsta praksa");
            specijalizacije.Add("Pedijatar");
            Specijalizacija.ItemsSource = specijalizacije;


        }

        private void DoktoriSpecijalizacija(object sender, RoutedEventArgs e)
        {
            String s =(String) Specijalizacija.SelectedItem;
            List<String> doktoriIzabraneSpecijalizacije = new List<String>();
            foreach(Doktor d in sviDoktori)
            {
                // if (s == d.Specijalizacija)
                s = "kdkjk";
                     doktoriIzabraneSpecijalizacije.Add(s);

                Doktor.ItemsSource = doktoriIzabraneSpecijalizacije;
            }
        
        }

        private void IzdavanjeUputa(object sender, RoutedEventArgs e)
        {

        }
    }
}

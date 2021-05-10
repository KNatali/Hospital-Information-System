using Model;
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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for SvaStatickaOprema.xaml
    /// </summary>
    public partial class SvaStatickaOprema : Window
    {
        public List<Prostorija> prostorije { get; set; }
        public List<Inventar> oprema { get; set; }
        public SvaStatickaOprema()
        {
            InitializeComponent();
            this.DataContext = this;

            oprema = new List<Inventar>();
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();


            foreach (Prostorija p in prostorije)
            {
                if (p.inventar != null && p.id != "0")
                {
                    oprema.AddRange(p.inventar);
                    
                }
            }
            dgrStatickaOprema.ItemsSource = oprema;
        }

        private void pretrazi(object sender, RoutedEventArgs e)
        {

            List<Inventar> noviInventar = new List<Inventar>();
            foreach (Inventar i in oprema)
            {
                if (i.ime == Pretraga.Text || i.prostorija == Pretraga.Text )
                {
                    noviInventar.Add(i);
                }
            }
            dgrStatickaOprema.ItemsSource = noviInventar;

        }
        private void ponisti(object sender, RoutedEventArgs e)
        {
            
            dgrStatickaOprema.ItemsSource = oprema;
            Pretraga.Text = "";
        }
    }
}

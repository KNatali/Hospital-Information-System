using Model;
using ProjekatSIMS.Service;
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

    public partial class PregledLekovaUpravnik : Page
    {

        public List<Lijek> Lekovi = new List<Lijek>();
        public LijekService LijekService = new LijekService();
        public PregledLekovaUpravnik()
        {
            InitializeComponent();
            this.DataContext = this;
            Lekovi = LijekService.lijekRepoisitory.DobaviSve();
            dgrLekovi.ItemsSource = Lekovi;
        }
        
        private void ObrisiLek(object sender, RoutedEventArgs e)
        {
            Lijek lekZaBrisanje = (Lijek)dgrLekovi.SelectedItems[0];
            LijekService.lijekRepoisitory.ObrisiLek(lekZaBrisanje.NazivLeka);

            Lekovi = LijekService.lijekRepoisitory.DobaviSve();
            dgrLekovi.ItemsSource = Lekovi;
        }
       
    }
}

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

namespace ProjekatSIMS.UpravnikWindows
{
    
    public partial class PregledLekova : Page
    {
        public List<Lijek> Lekovi { get; set; }
        public LijekService LijekService { get; set; }
        public PregledLekova()
        {
            InitializeComponent();
            LijekService = new LijekService();
            Lekovi = new List<Lijek>(LijekService.lijekRepoisitory.DobaviSve());
            dgrLekovi.ItemsSource = Lekovi;

        }
        private void ObrisiLek(object sender, RoutedEventArgs e)
        {
            Lijek lekZaBrisanje = (Lijek)dgrLekovi.SelectedItems[0];
            LijekService.lijekRepoisitory.ObrisiLek(lekZaBrisanje.NazivLeka);

            Lekovi = LijekService.lijekRepoisitory.DobaviSve();
            dgrLekovi.ItemsSource = Lekovi;
        }
        private void IzmeniLek(object sender, RoutedEventArgs e)
        {
            Lijek l = (Lijek)dgrLekovi.SelectedItems[0];
            Upravnik uw = (Upravnik)Window.GetWindow(this);
            uw.UpravnikFrame.Content = new IzmeniLek(l);
        }
    }
}

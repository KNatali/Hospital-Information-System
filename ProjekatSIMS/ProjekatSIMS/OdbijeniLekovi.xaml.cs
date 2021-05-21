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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    
    public partial class OdbijeniLekovi : Window
    {
        public List<Lijek> odbijeniLekovi { get; set; }
        public LijekService LijekService { get; set; }
        public OdbijeniLekovi()
        {
            InitializeComponent();
            this.DataContext = this;
            LijekService = new LijekService();
            odbijeniLekovi = LijekService.DobaviOdbijene();

            dgrLekovi.ItemsSource = odbijeniLekovi;

        }

        private void izmeniLek(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dgrLekovi.SelectedItems[0];
            IzmeniOdbijenLek iz = new IzmeniOdbijenLek(lijek);
            iz.Show();
        }

        private void obrisiLek(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dgrLekovi.SelectedItems[0];
            LijekService.lijekRepoisitory.ObrisiLek(lijek);
            odbijeniLekovi = LijekService.DobaviOdbijene();
            dgrLekovi.ItemsSource = odbijeniLekovi;
        }
    }
}

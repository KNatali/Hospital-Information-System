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
    
    public partial class OdobreniLekovi : Window
    {
        public List<Lijek> odobreniLekovi { get; set; }
        public LijekService LijekService { get; set; }
        public OdobreniLekovi()
        {
            InitializeComponent();
            this.DataContext = this;
            LijekService = new LijekService();
            odobreniLekovi = new List<Lijek>();
            odobreniLekovi = LijekService.DobaviPoStatusu(Model.OdobravanjeLekaEnum.Odobren);

            dgrLekovi.ItemsSource = odobreniLekovi;
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
            
            odobreniLekovi = LijekService.DobaviPoStatusu(Model.OdobravanjeLekaEnum.Odobren); 
            
            dgrLekovi.ItemsSource = odobreniLekovi;
        }
    }
}

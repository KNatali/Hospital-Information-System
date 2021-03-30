using ProjekatSIMS.Model.PacijentModel;
using System.Windows;

namespace ProjekatSIMS
{

    public partial class PacijentWindow : Window
    {
        public PacijentWindow()
        {
            InitializeComponent();
        }
        private void Click_zakazi(object sender, RoutedEventArgs e)
        {
            ZakaziWindow zw = new ZakaziWindow();
            zw.Show();
        }

        private void Click_otkazi(object sender, RoutedEventArgs e)
        {
            OtkaziWindow ow = new OtkaziWindow();
            ow.Show();
        }

        private void Click_izmeni(object sender, RoutedEventArgs e)
        {
            IzmeniWindow iw = new IzmeniWindow();
            iw.Show();
        }

        private void Click_vidi(object sender, RoutedEventArgs e)
        {
            VidiWindow vw = new VidiWindow();
            vw.Show();
        }
    }
}

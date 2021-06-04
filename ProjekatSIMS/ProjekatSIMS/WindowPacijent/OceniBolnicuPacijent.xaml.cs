using ProjekatSIMS.Controller;
using ProjekatSIMS.Model;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
   
    public partial class OceniBolnicuPacijent : Page
    {
        public OceniBolnicuPacijent()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Oceni(object sender, RoutedEventArgs e)
        {
            OcenaBolnice ob = new OcenaBolnice();
            string ocena = Ocena.Text;
            string komentar = Komentar.Text;

            OcenaController ocenaCont = new OcenaController();
            if (ocenaCont.ProsledjenaOcenaBolnice(ocena, komentar) == true)
            {
                MessageBox.Show("Hvala Vam sto ste izdvojili vreme da ocenite nasu bolnicu!");
            }
            else
            {
                MessageBox.Show("Molimo Vas unesite ocenu bolnice.");
            }
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}

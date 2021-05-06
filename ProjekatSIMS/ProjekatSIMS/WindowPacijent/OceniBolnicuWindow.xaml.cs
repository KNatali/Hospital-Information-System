
using ProjekatSIMS.Controller;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System.Collections.Generic;
using System.Windows;
namespace ProjekatSIMS.WindowPacijent
{
   
    public partial class OceniBolnicuWindow : Window
    {
        public OceniBolnicuWindow()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void Oceni_Click(object sender, RoutedEventArgs e)
        {
            OcenaBolnice ob = new OcenaBolnice();
            string ocena = Ocena.Text;
            string komentar = Komentar.Text;

            OcenaController ocenaCont = new OcenaController();
            if(ocenaCont.ProsledjenaOcenaBolnice(ocena,komentar) == true)
            {
                MessageBox.Show("Hvala Vam sto ste izdvojili vreme da ocenite nasu bolnicu!");

                this.Close();
            }
            else
            {
                MessageBox.Show("Molimo Vas unesite ocenu bolnice.");
            }

           
            

        }
    }
}

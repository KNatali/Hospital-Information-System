using Controller;
using ProjekatSIMS.Model;
using System;

using System.Windows;


namespace ProjekatSIMS.WindowPacijent
{
    /// <summary>
    /// Interaction logic for KreirajPodsetnikWindow.xaml
    /// </summary>
    public partial class KreirajPodsetnikWindow : Window
    {
        public KreirajPodsetnikWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            Podsetnik podsetnik = new Podsetnik();
            String naziv = Naziv.Text;
            String opis = Opis.Text;
            DateTime datumPocetka = (DateTime)DatumPocetka.SelectedDate;
            DateTime datumKraja = (DateTime)DatumKraja.SelectedDate;
            String ime = Ime.Text;
            String prezime = Prezime.Text;

            PodsetnikController podsetnikController = new PodsetnikController();
            if(podsetnikController.KreiranjePodsetnika(naziv,opis,datumPocetka,datumKraja,ime, prezime) == true)
            {
                MessageBox.Show("Uspesno ste kreirali svoj podsetnik");
                this.Close();
            }

        }
    }
}

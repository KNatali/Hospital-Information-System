using Controller;
using ProjekatSIMS.Model;
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

            PodsetnikController podsetnikController = new PodsetnikController();
            if(podsetnikController.KreiranjePodsetnika(naziv,opis,datumPocetka,datumKraja,"Biljana","Marinkov") == true)
            {
                MessageBox.Show("Uspesno ste kreirali svoj podsetnik");
                this.Close();
            }

        }
    }
}

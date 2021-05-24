using Controller;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class KreiranjePodsetnika : Page
    {
        public KreiranjePodsetnika()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            Podsetnik podsetnik = new Podsetnik();
            String naziv = Naziv.Text;
            String opis = Opis.Text;
            DateTime datumPocetka = (DateTime)DatumPocetka.SelectedDate;
            DateTime datumKraja = (DateTime)DatumKraja.SelectedDate;
            String ime = Ime.Text;
            String prezime = Prezime.Text;

            PodsetnikController podsetnikController = new PodsetnikController();
            if (podsetnikController.KreiranjePodsetnika(naziv, opis, datumPocetka, datumKraja, ime, prezime) == true)
            {
                MessageBox.Show("Uspesno ste kreirali svoj podsetnik");
                
            }
        }
    }
}

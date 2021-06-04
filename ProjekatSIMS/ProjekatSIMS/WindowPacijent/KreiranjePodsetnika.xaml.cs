using Controller;
using Model;
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
        public Pacijent trenutniPacijent { get; set; }
        public KreiranjePodsetnika(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;
        }

        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            Podsetnik podsetnik = new Podsetnik();
            String naziv = Naziv.Text;
            String opis = Opis.Text;
            DateTime datumPocetka = (DateTime)DatumPocetka.SelectedDate;
            DateTime datumKraja = (DateTime)DatumKraja.SelectedDate;
            String ime = trenutniPacijent.Ime;
            String prezime = trenutniPacijent.Prezime;

            PodsetnikController podsetnikController = new PodsetnikController();
            if (podsetnikController.KreiranjePodsetnika(naziv, opis, datumPocetka, datumKraja, "5555") == true)
            {
                MessageBox.Show("Uspesno ste kreirali svoj podsetnik");
                
            }
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}

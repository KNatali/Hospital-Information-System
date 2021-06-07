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
using Controller;
using Model;

namespace ProjekatSIMS.ViewSekretar
{
    public partial class ProfilPacijentaView : Window
    {
        public Pacijent p { get; set; }
        public ProfilPacijentaView(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = new ViewModelSekretar.ProfilPacijentaViewModel(pacijent, this);
            p = pacijent;
        }
        private void Sacuvaj_izmene(object sender, RoutedEventArgs e)
        {
            PrikupljanjePodatakaPacijentaIzTextBoxa();
            PacijentController pacijentController = new PacijentController();
            if (pacijentController.CuvanjeIzmenjenjihPodataka(p) == true)
                MessageBox.Show("Podaci pacijenta su uspešno izmenjeni.");
            this.Close();
        }
        private void PrikupljanjePodatakaPacijentaIzTextBoxa()
        {
            p.Ime = Ime.Text;
            p.Prezime = Prezime.Text;
            p.BrojTelefona = Telefon.Text;
            p.Email = Mail.Text;
            p.Adresa = Adresa.Text;
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Obrisi_profil(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete pacijenta?", "PROVERA", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                PacijentController pacijentController = new PacijentController();
                BrisanjePacijenta(pacijentController);
                this.Close();
            }
        }

        private void BrisanjePacijenta(PacijentController pacijentController)
        {
            if (pacijentController.ObrisiPacijenta(p) == true)
                MessageBox.Show("Pacijent je uspešno obrisan.", "OBAVEŠTENJE");
        }

        private void Lista_alergena(object sender, RoutedEventArgs e)
        {
            ListaAlergenaSWindow la = new ListaAlergenaSWindow(p);
            la.Show();
        }

        private void Zakazi_pregled(object sender, RoutedEventArgs e)
        {
            OdabirPrioritetaSWindow op = new OdabirPrioritetaSWindow(p);
            op.Show();
        }
    }
}

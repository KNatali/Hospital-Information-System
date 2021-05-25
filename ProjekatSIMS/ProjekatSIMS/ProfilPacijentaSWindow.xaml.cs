using Controller;
using Model;
using Repository;
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
    public partial class ProfilPacijentaSWindow : Window
    {
        public OsobaRepository fajl { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent pacijent { get; set; }
        public ProfilPacijentaSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pacijent = p;
            Jmbg.Text = pacijent.Jmbg;
            Ime.Text = pacijent.Ime;
            Prezime.Text = pacijent.Prezime;
            Datum.Text = pacijent.DatumRodjenja.ToString();
            Mail.Text = pacijent.Email;
            Telefon.Text = pacijent.BrojTelefona;
            Adresa.Text = pacijent.Adresa;
        }
        private void Sacuvaj_izmene(object sender, RoutedEventArgs e)
        {
            PrikupljanjePodatakaPacijentaIzTextBoxa();
            PacijentController pacijentController = new PacijentController();
            if (pacijentController.CuvanjeIzmenjenjihPodataka(pacijent) == true)
                MessageBox.Show("Podaci pacijenta su uspešno izmenjeni.");
            this.Close();
        }
        private void PrikupljanjePodatakaPacijentaIzTextBoxa()
        {
            pacijent.Ime = Ime.Text;
            pacijent.Prezime = Prezime.Text;
            pacijent.BrojTelefona = Telefon.Text;
            pacijent.Email = Mail.Text;
            pacijent.Adresa = Adresa.Text;
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Obrisi_profil(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete pacijenta?", "PROVERA", MessageBoxButton.YesNo);
            if(ret==MessageBoxResult.Yes)
            {
                PacijentController pacijentController = new PacijentController();
                BrisanjePacijenta(pacijentController);
                this.Close();
            }
        }

        private void BrisanjePacijenta(PacijentController pacijentController)
        {
            if (pacijentController.ObrisiPacijenta(pacijent) == true)
                MessageBox.Show("Pacijent je uspešno obrisan.", "OBAVEŠTENJE");
        }

        private void Lista_alergena(object sender, RoutedEventArgs e)
        {
            ListaAlergenaSWindow la = new ListaAlergenaSWindow(pacijent);
            la.Show();
        }

        private void Zakazi_pregled(object sender, RoutedEventArgs e)
        {
            OdabirPrioritetaSWindow op = new OdabirPrioritetaSWindow(pacijent);
            op.Show();
        }

        private void Kalendar(object sender, RoutedEventArgs e)
        {

        }
    }
}

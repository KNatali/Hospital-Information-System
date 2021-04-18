using Model;
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
        public CuvanjePacijenta fajl { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent pac { get; set; }
        public ProfilPacijentaSWindow(String ime, String prezime)
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            List<Pacijent> ListaPacijenata = new List<Pacijent>();
            CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\Pacijent.txt");
            ListaPacijenata = fajl.DobaviPacijente();
            foreach (Pacijent p in ListaPacijenata)
            {
                if (p.Ime == ime && p.Prezime == prezime)
                {
                    Pacijenti.Add(p);
                    pac = p;
                }
            }
        }
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            pac.Ime = Ime.Text;
            pac.Prezime = Prezime.Text;
            pac.BrojTelefona = Telefon.Text;
            pac.Email = Mail.Text;
            pac.Adresa = Adresa.Text;
            List<Pacijent> ListaPacijenata = new List<Pacijent>();
            CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\Pacijent.txt");
            ListaPacijenata = fajl.DobaviPacijente();
            foreach (Pacijent p in ListaPacijenata)
            {
                if (pac.Jmbg == p.Jmbg)
                {
                    p.Ime = pac.Ime;
                    p.Prezime = pac.Prezime;
                    p.BrojTelefona = pac.BrojTelefona;
                    p.Email = pac.Email;
                    p.Adresa = pac.Adresa;
                }
            }
            fajl.Sacuvaj(ListaPacijenata);

            this.Close();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Obrisi(object sender, RoutedEventArgs e)
        {
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];

            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete pacijenta?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    if (p.ObrisiPacijent() == true)
                    {
                        CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\Pacijent.txt");
                        List<Pacijent> pacijent = fajl.DobaviPacijente();
                        foreach (Pacijent pa in pacijent)
                        {
                            if (pa.Jmbg == p.Jmbg)
                            {
                                pacijent.Remove(pa);
                                break;
                            }
                        }
                        fajl.Sacuvaj(pacijent);
                        MessageBox.Show("Pacijent je uspešno obrisan.", "OBAVEŠTENJE");
                        this.Close();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Lista_alergena(object sender, RoutedEventArgs e)
        {
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            ListaAlergenaSWindow la = new ListaAlergenaSWindow(p);
            la.Show();
        }
    }
}

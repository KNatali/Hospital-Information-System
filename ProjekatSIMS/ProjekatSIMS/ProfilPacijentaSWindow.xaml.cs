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
        public Pacijent pac { get; set; }
        public ProfilPacijentaSWindow(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = pacijent;
            Jmbg.Text = pac.Jmbg;
            Ime.Text = pac.Ime;
            Prezime.Text = pac.Prezime;
            Datum.Text = pac.DatumRodjenja.ToString();
            Mail.Text = pac.Email;
            Telefon.Text = pac.BrojTelefona;
            Adresa.Text = pac.Adresa;
            /*Pacijenti = new List<Pacijent>();
            List<Pacijent> ListaPacijenata = new List<Pacijent>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            ListaPacijenata = fajl.DobaviPacijente();
            foreach (Pacijent p in ListaPacijenata)
            {
                if (p.Ime == ime && p.Prezime == prezime)
                {
                    Pacijenti.Add(p);
                    pac = p;
                }
            }*/
        }
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            pac.Ime = Ime.Text;
            pac.Prezime = Prezime.Text;
            pac.BrojTelefona = Telefon.Text;
            pac.Email = Mail.Text;
            pac.Adresa = Adresa.Text;
            List<Pacijent> novaListaPacijenata = new List<Pacijent>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            novaListaPacijenata = fajl.DobaviPacijente();
            foreach (Pacijent p in novaListaPacijenata)
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
            fajl.Sacuvaj(novaListaPacijenata);

            this.Close();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Obrisi(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete pacijenta?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    if (pac.ObrisiPacijent() == true)
                    {
                        OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
                        List<Pacijent> pacijent = fajl.DobaviPacijente();
                        foreach (Pacijent pa in pacijent)
                        {
                            if (pa.Jmbg == pac.Jmbg)
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
            ListaAlergenaSWindow la = new ListaAlergenaSWindow(pac);
            la.Show();
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            OdabirPrioritetaSWindow op = new OdabirPrioritetaSWindow(pac);
            op.Show();
        }

        private void Kalendar(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    public partial class OdabirPacijentaHitnoSWindow : Window
    {
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent pac { get; set; }
        public OdabirPacijentaHitnoSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            Pacijenti = fajl.DobaviPacijente();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete zakazivanje hitnog pregleda?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            ComboBoxItem izborPacijenta = (ComboBoxItem)Nalog.SelectedItem;
            string opcija = izborPacijenta.Content.ToString();
            if (opcija == "Kreiraj hitan nalog")
            {
                Pacijent p = KreiranjeHitnogNaloga();
                HitanPregledSWindow hp = new HitanPregledSWindow(p);
                hp.Show();
                this.Close();
            }
            else if (opcija == "Odaberi postojeći nalog")
            {
                Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
                HitanPregledSWindow hp = new HitanPregledSWindow(p);
                hp.Show();
                this.Close();
            }
        }

        private Pacijent KreiranjeHitnogNaloga()
        {
            String jmbg = Jmbg.Text;
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            Pacijent p = new Pacijent();
            p.Jmbg = jmbg;
            p.Ime = ime;
            p.Prezime = prezime;
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            List<Pacijent> pacijenti = fajl.DobaviPacijente();
            pacijenti.Add(p);
            fajl.Sacuvaj(pacijenti);
            return p;
        }

        private void Prikaz(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)Nalog.SelectedItem;
            string opcija = cbi.Content.ToString();
            if (opcija == "Kreiraj hitan nalog")
            {
                PrikaPoljaZaKreiranjeHitnogNaloga();
            }
            else if (opcija == "Odaberi postojeći nalog")
            {
                PrikazTabeleSaSvimPacijentima();
            }
        }

        private void PrikazTabeleSaSvimPacijentima()
        {
            dataGridPacijenti.Visibility = Visibility.Visible;
            dataGridPacijenti.ItemsSource = Pacijenti;
            LabelaJMBG.Visibility = Visibility.Hidden;
            LabelaIme.Visibility = Visibility.Hidden;
            LabelaPrezime.Visibility = Visibility.Hidden;
            Jmbg.Visibility = Visibility.Hidden;
            Ime.Visibility = Visibility.Hidden;
            Prezime.Visibility = Visibility.Hidden;
        }

        private void PrikaPoljaZaKreiranjeHitnogNaloga()
        {
            LabelaJMBG.Visibility = Visibility.Visible;
            LabelaIme.Visibility = Visibility.Visible;
            LabelaPrezime.Visibility = Visibility.Visible;
            Jmbg.Visibility = Visibility.Visible;
            Ime.Visibility = Visibility.Visible;
            Prezime.Visibility = Visibility.Visible;
            dataGridPacijenti.Visibility = Visibility.Hidden;
        }
    }
}

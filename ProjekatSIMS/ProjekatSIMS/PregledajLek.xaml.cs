using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
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
    
    public partial class PregledajLek : Window
    {
        public List<Lijek> Lekovi { get; set; }
        public Lijek Lek1 { get; set; }
        public List<String> AlergeniLeka { get; set; }
        public PregledajLek(Lijek lek)
        {
            Lek1 = lek;
            InitializeComponent();
            this.DataContext = this;
            
            LijekRepository lekRepository = new LijekRepository();
            List<Lijek> lekovi1 = lekRepository.DobaviSveLekove();
            List<Lijek> slLekovi = new List<Lijek>();
            AlergeniLeka = new List<string>();

            Lekovi = new List<Lijek>();
            foreach(Lijek l in lekovi1)
            {
                if(l.NazivLeka == lek.NazivLeka)
                {
                    slLekovi = l.AlternativniLekovi;
                    AlergeniLeka = l.Alergeni;
                }
                if(l.NazivLeka != lek.NazivLeka)
                {
                    Lekovi.Add(l);
                }

            }

            dgrAlergeni.ItemsSource = AlergeniLeka;
            dgrLekovi.ItemsSource = slLekovi;

        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            //Lek.SelectedItem
        }
        private void dodajAl (object sender, RoutedEventArgs e)
        {
            String al = Alergen.Text;
            List<String> alergeni = Lek1.Alergeni;
            if(alergeni == null)
            {
                Lek1.Alergeni.Add(al);
                MessageBox.Show("Uspesno ste dodali alergen!");
                this.Close();

            }
            foreach(String s in alergeni)
            {
                if(s == al)
                {
                    MessageBox.Show("Vec ste uneli dati alergen!");
                    break;
                }
            }
            Lek1.Alergeni.Add(al);
            MessageBox.Show("Uspesno ste dodali alergen!");
            this.Close();
        }
        private void obrisiAl(object sender, RoutedEventArgs e)
        {
            String string1 = (String)dgrAlergeni.SelectedItems[0];
            List<String> alergeni = Lek1.Alergeni;
            foreach (String s in alergeni)
            {
                if (s == string1)
                {
                    Lek1.Alergeni.Remove(s);
                    MessageBox.Show("Izabrani alergen je obrisan!");
                    break;
                }
            }
            this.Close();

        }

        private void sacuvaj(object sender, RoutedEventArgs e)
        {

        }
    }
}

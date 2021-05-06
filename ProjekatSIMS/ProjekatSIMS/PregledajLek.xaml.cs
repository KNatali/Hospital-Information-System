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
        public List<String> Lekovi { get; set; }
        public Lijek Lek1 { get; set; }
        public List<String> AlergeniLeka { get; set; }
        
        public PregledajLek(Lijek lek)
        {
            Lek1 = lek;
            InitializeComponent();
            this.DataContext = this;
            
            LijekRepository lekRepository = new LijekRepository();
            List<Lijek> lekovi1 = lekRepository.DobaviSveLekove();
            
            Lek1 = lek;
            
            AlergeniLeka = new List<string>();

            Lekovi = new List<String>();
            foreach(Lijek l in lekovi1)
            {
                
                if(l.NazivLeka != lek.NazivLeka)
                {
                    Lekovi.Add(l.NazivLeka);
                }

            }
            

            Alergeni.ItemsSource = Lek1.Alergeni;
            AlternativniLekovi.ItemsSource = Lek1.AlternativniLekovi;

        }

        private void obrisi(object sender, RoutedEventArgs e)
        {

            String al = AlternativniLek.Text;
            int flag = 0;

            foreach (String s in Lek1.AlternativniLekovi)
            {
                if (s.Equals(al, StringComparison.OrdinalIgnoreCase))
                {
                    Lek1.AlternativniLekovi.Remove(s);
                    MessageBox.Show("Izabrani alternativni lek je obrisan!");
                    flag++;
                    break;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("Uneli ste nepostojeci alternativni lek!");
            }
            AlternativniLek.Text = "";
            AlternativniLekovi.ItemsSource = Lek1.AlternativniLekovi;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            Lijek l = (Lijek)Lek.SelectedItem;
            int temp = 0;
            if(Lek1.AlternativniLekovi == null)
            {
                Lek1.AlternativniLekovi.Add(l.NazivLeka);
            }
            foreach(String s in Lek1.AlternativniLekovi)
            {
                if(s.Equals(l.NazivLeka, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Vec postoji unesen alternativni lek sa tim nazivom!");
                    temp++;
                    break;
                }
                
            }
            if(temp == 0)
            {
                Lek1.AlternativniLekovi.Add(l.NazivLeka);
            }
            
            AlternativniLekovi.ItemsSource = Lek1.AlternativniLekovi;

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
                if(s.Equals(al, StringComparison.OrdinalIgnoreCase))
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
            String al = Alergen.Text;
            int flag = 0;
            
            foreach (String s in Lek1.Alergeni)
            {
                if (s.Equals(al, StringComparison.OrdinalIgnoreCase))
                {
                    Lek1.Alergeni.Remove(s);
                    MessageBox.Show("Izabrani alergen je obrisan!");
                    flag++;
                    break;
                }
            }
            if(flag == 0)
            {
                MessageBox.Show("Uneli ste nepostojeci alergen!");
            }
            Alergeni.ItemsSource = Lek1.Alergeni;

        }

        private void sacuvaj(object sender, RoutedEventArgs e)
        {

        }
    }
}

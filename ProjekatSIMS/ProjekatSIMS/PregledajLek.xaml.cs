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
using System.Linq;
namespace ProjekatSIMS
{
    
    public partial class PregledajLek : Window
    {
        public List<String> Lekovi { get; set; }
        public Lijek Lek1 { get; set; }
        public List<String> AlergeniLeka { get; set; }
        public List<Lijek> lekovi1 { get; set; }
        public PregledajLek(Lijek lek)
        {
            Lek1 = lek;
            InitializeComponent();
            this.DataContext = this;
            
            LijekRepository lekRepository = new LijekRepository();
             lekovi1 = lekRepository.DobaviSveLekove();
            
            Lek1 = lek;
            
            AlergeniLeka = new List<string>();

            Lekovi = new List<String>();
            foreach(Lijek l in lekovi1)
            {
                
                if(l.NazivLeka != lek.NazivLeka && l.Status == OdobravanjeLekaEnum.Odobren)
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
                    LijekRepository lekRepository = new LijekRepository();
                    foreach (Lijek l in lekovi1)
                    {
                        if (Lek1.NazivLeka == l.NazivLeka)
                        {
                            l.AlternativniLekovi = Lek1.AlternativniLekovi;
                            break;
                        }
                    }
                    lekRepository.SacuvajLekove(lekovi1);
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

            String l = Convert.ToString(Lek.SelectedItem);
            List<String> lista = new List<string>();
            lista.Add(l);
            int temp = 0;
            if(Lek1.AlternativniLekovi == null)
            {
                Lek1.AlternativniLekovi = lista;
            }
            foreach(String s in Lek1.AlternativniLekovi)
            {
                if(s.Equals(l, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Vec postoji unesen alternativni lek sa tim nazivom!");
                    temp++;
                    break;
                }
                
            }
            if(temp == 0)
            {
                Lek1.AlternativniLekovi.Add(l);
                LijekRepository lekRepository = new LijekRepository();
                foreach (Lijek l1 in lekovi1)
                {
                    if (Lek1.NazivLeka == l1.NazivLeka)
                    {
                        l1.AlternativniLekovi = Lek1.AlternativniLekovi;
                        break;
                    }
                }
                lekRepository.SacuvajLekove(lekovi1);
            }
            
            AlternativniLekovi.ItemsSource = Lek1.AlternativniLekovi;

        }
        private void dodajAl (object sender, RoutedEventArgs e)
        {
            String al = Alergen.Text;
            List<String> alergeni = Lek1.Alergeni;
            int temp = 0;
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
                    temp++;
                    break;
                }
            }
            if(temp == 0)
            {
                Lek1.Alergeni.Add(al);
                MessageBox.Show("Uspesno ste dodali alergen!");
                LijekRepository lekRepository = new LijekRepository();
                foreach (Lijek l in lekovi1)
                {
                    if(Lek1.NazivLeka == l.NazivLeka)
                    {
                        l.Alergeni = Lek1.Alergeni;
                        break;
                    }
                }
                lekRepository.SacuvajLekove(lekovi1);
            }

            Alergeni.ItemsSource = Lek1.Alergeni;
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
                    LijekRepository lekRepository = new LijekRepository();
                    foreach (Lijek l in lekovi1)
                    {
                        if (Lek1.NazivLeka == l.NazivLeka)
                        {
                            l.Alergeni = Lek1.Alergeni;
                            break;
                        }
                    }
                    lekRepository.SacuvajLekove(lekovi1);
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
            Lek1.Opis = Opis.Text;
            Lek1.AlternativniLekovi = new List<string>(AlternativniLekovi.Items.Cast<String>());
            Lek1.Alergeni = new List<string>(Alergeni.Items.Cast<String>());
            LijekRepository lekRepository = new LijekRepository();
            foreach (Lijek l in lekovi1)
            {
                if (Lek1.NazivLeka == l.NazivLeka)
                {
                    l.Opis = Lek1.Opis;
                    l.Alergeni = Lek1.Alergeni;
                    l.AlternativniLekovi = Lek1.AlternativniLekovi;
                    break;
                }
            }
            lekRepository.SacuvajLekove(lekovi1);
            this.Close();
        }
    }
}

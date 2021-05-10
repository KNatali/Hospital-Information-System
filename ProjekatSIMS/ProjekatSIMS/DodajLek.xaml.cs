using Model;
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
    /// <summary>
    /// Interaction logic for DodajLek.xaml
    /// </summary>
    public partial class DodajLek : Window
    {
        public List<Lijek> Lekovi { get; set; }
        public List<String> Lekovi1 { get; set; }
        
        public Lijek Lek1 { get; set; }
        public DodajLek()
        {
            InitializeComponent();
            this.DataContext = this;

            LijekRepository lekRepository = new LijekRepository();
            Lekovi = lekRepository.DobaviSveLekove();
            Lek1 = new Lijek();
            Lekovi1 = new List<String>();

            Alergeni.ItemsSource = Lek1.Alergeni;
            foreach(Lijek l in Lekovi)
            {
                if(l.Status == Model.OdobravanjeLekaEnum.Odobren)
                {
                    Lekovi1.Add(l.NazivLeka);
                }
                
            }

            AlternativniLekovi.ItemsSource = Lek1.AlternativniLekovi;



        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            //biramo lek
            String l = Convert.ToString(Lek.SelectedItem);
            List<String> lista = new List<string>();
            lista.Add(l);
            int temp = 0;
            //proverimo da li je lista alternativnih prazna
            //ako jeste unosimo lek
            if (Lek1.AlternativniLekovi == null)
            {
                Lek1.AlternativniLekovi = lista;
                MessageBox.Show("Uspesno ste dodali alternativni lek!");
            }
            //ako nije proverimo ima li vec taj lek
            foreach (String s in Lek1.AlternativniLekovi)
            {
                if (s.Equals(l, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Vec postoji unesen alternativni lek sa tim nazivom!");
                    temp++;
                    break;
                }

            }
            //ako ne postoji dodajemo ga 
            if (temp == 0)
            {
                Lek1.AlternativniLekovi.Add(l);
                MessageBox.Show("Uspesno ste dodali alternativni lek!");
            }

            AlternativniLekovi.ItemsSource = Lek1.AlternativniLekovi;






            
            
            

        }
        private void dodajAl(object sender, RoutedEventArgs e)
        {
            String al = Alergen.Text;
            int temp = 0;
            List<String> lista = new List<string>();
            lista.Add(al);
            if(Lek1.Alergeni == null)
            {
                Lek1.Alergeni = lista;

                MessageBox.Show("Uspesno ste dodali alergen!");
            }


            foreach (String s in Lek1.Alergeni)
            {
                if (s.Equals(al, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Vec ste uneli dati alergen!");
                    temp++;
                    break;
                }
            }
            if(temp == 0)
            {
                Lek1.Alergeni.Add(al);
                MessageBox.Show("Uspesno ste uneli alergen!");
            }
            Alergeni.ItemsSource = Lek1.Alergeni;

        }
        private void sacuvaj(object sender, RoutedEventArgs e)
        {
            int temp = 0;
            Lijek l = new Lijek();
            l.NazivLeka = Naziv.Text;
            foreach(Lijek l1 in Lekovi)
            {
                if(l1.NazivLeka.Equals(l.NazivLeka, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Vec postoji lek sa istim nazivom!");
                    temp++;
                    break;
                }

            }
            l.Opis = Opis.Text;
            l.Alergeni = new List<string>(Alergeni.Items.Cast<String>());
            l.AlternativniLekovi = new List<string>(AlternativniLekovi.Items.Cast<String>());
            l.Status = Model.OdobravanjeLekaEnum.Ceka;
            l.PorukaOdbaci = "";
            if(temp == 0)
            {
                Lekovi.Add(l);

            }
            LijekRepository lekRepository = new LijekRepository();
            lekRepository.SacuvajLekove(Lekovi);
            this.Close();
            

        }
    }
}

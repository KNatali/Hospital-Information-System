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
    
    public partial class StatickaOpremaWindow : Window
    {
        public Prostorija prostorija { get; set; }
        public StatickaOpremaWindow(Prostorija pros)
        {
            InitializeComponent();
            this.DataContext = this;
            List<Inventar> oprema = new List<Inventar>();
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();


            foreach (Prostorija p in prostorije)
            {
                if (pros.id == p.id)
                {
                    oprema = p.inventar;
                }
            }
            dgrStatickaOprema.ItemsSource = oprema;
            prostorija = pros;
            Prostorije.ItemsSource = prostorije;
        }
    

        private void rasporedi1(object sender, RoutedEventArgs e)
        {


        }

        private void dodaj1(object sender, RoutedEventArgs e)
        {
            Inventar inventar = new Inventar();
            inventar.id = Convert.ToInt32(Id.Text);
            inventar.ime = Ime.Text;
            inventar.kolicina = Convert.ToInt32(Kolicina.Text);
            
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();

            foreach (Prostorija p in prostorije)
            {

                foreach(Inventar i in p.inventar)
                {
                    if(i.id == inventar.id)
                    {
                        MessageBox.Show("Vec postoji inventar sa tom sifrom!");
                        break;
                            
                    }
                }
            }



            foreach (Prostorija p in prostorije)
            {
                if (prostorija.id == p.id)
                {
                    p.inventar.Add(inventar);
                }
            }
            cuvanje.Sacuvaj(prostorije);

            MessageBox.Show("Inventar je rasporedjen!");
            this.Close();

        }

        private void obrisi1(object sender, RoutedEventArgs e)
        {

        }
    }
}

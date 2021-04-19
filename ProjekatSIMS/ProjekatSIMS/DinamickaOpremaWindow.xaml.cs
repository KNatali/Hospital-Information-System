using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    public partial class DinamickaOpremaWindow : Window
    {
        public DinamickaOpremaWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Inventar> oprema = new List<Inventar>();
            




            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije= cuvanje.UcitajProstorije();
            foreach(Prostorija p in prostorije)
            {
                if(Convert.ToInt32(p.id) == 0)
                {
                    oprema = p.inventar;
                }
            }
            dgrDinamickaOprema.ItemsSource = oprema;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            Inventar inventar = new Inventar();
            inventar.id = Convert.ToInt32(Id.Text);
            inventar.ime = Ime.Text;
            inventar.kolicina = Convert.ToInt32(Kolicina.Text);
            inventar.Staticka = true;
            
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();
            foreach (Prostorija p in prostorije)
            {

                if (Convert.ToInt32(p.id) == 0)
                {
                    foreach(Inventar i in p.inventar)
                    {
                        if (Convert.ToInt32(Id.Text) == i.id || Ime.Text == i.ime)
                        {
                            MessageBox.Show("Vec postoji inventar sa tim parametrima!");
                            break;
                        }
                    }
                    
                    p.inventar.Add(inventar);
                    
                }
            }
            cuvanje.Sacuvaj(prostorije);
            MessageBox.Show("Inventar je azuriran.");
            this.Close();

        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
           

        }
        private void obrisi(object sender, RoutedEventArgs e)
        {
            Inventar inventar = new Inventar();
            inventar = (Inventar)dgrDinamickaOprema.SelectedItems[0];


            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = cuvanje.UcitajProstorije();
            foreach (Prostorija pros in prostorije)

            {
                if (Convert.ToInt32(pros.id) == 0) //pronasli smo magacin
                {
                    foreach (Inventar i in pros.inventar)
                    {
                        if(i.id == inventar.id) //pronasli smo trazeni inventar
                        {
                            pros.inventar.Remove(i); //brisemo iz liste 
                            break;

                        }
                    }
                }
            }
               

            
            cuvanje.Sacuvaj(prostorije); //cuvamo izmenjenu listu 

            MessageBox.Show("Inventar je rasporedjen!");
            this.Close();

        }
    }
}

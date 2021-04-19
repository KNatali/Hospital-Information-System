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
    /// <summary>
    /// Interaction logic for DinamickaOpremaWindow.xaml
    /// </summary>
    public partial class DinamickaOpremaWindow : Window
    {
        public DinamickaOpremaWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            //ObservableCollection<Inventar> oprema = new ObservableCollection<Inventar>();
            Inventar[] oprema = null;
            




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
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();
            foreach (Prostorija p in prostorije)
            {

                if (Convert.ToInt32(p.id) == 0)
                {
                    Inventar[] array = p.inventar;
                    foreach (Inventar i in array)
                    {
                        if(i.ime == Ime.Text || i.id == Convert.ToInt32(Id.Text))
                        {
                            break;
                        }
                    }
                        var duzina = p.inventar.Length;
                    if(array == null)
                    {
                        break;
                    }
                    Array.Resize(ref array, duzina + 1);
                    array[duzina] = inventar;
                    p.inventar = array;
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
           
        }
    }
}

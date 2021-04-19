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
    /// <summary>
    /// Interaction logic for ProstorijeWindow.xaml
    /// </summary>
    public partial class ProstorijeWindow : Window
    {
        
        public ProstorijeWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();
            
            dgrProstorije.ItemsSource = prostorije;
           

        }
        private void dodaj(object sender, RoutedEventArgs e)
        {
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            Prostorija prostorija = new Prostorija();
            prostorija.id = Id.Text;
            prostorija.sprat = Convert.ToInt32(Sprat.Text);

           if(Sala.IsChecked == true)
            {
                var s = VrstaProstorije.Sala;
                prostorija.vrsta = s;
            }
           else
           if(Soba.IsChecked == true)
           {
                prostorija.vrsta = VrstaProstorije.Soba;
            }
           else
            if (Kancelarija.IsChecked == true)
            {
                prostorija.vrsta = VrstaProstorije.Kancelarija;
            }
            else
                prostorija.vrsta = VrstaProstorije.Ordinacija;

            prostorija.pregled = null;
            prostorija.inventar = null;

            List<Prostorija> prostorije = new List<Prostorija>();
            if (cuvanje.UcitajProstorije() == null)
            {
                prostorije.Add(prostorija);
            }
            else
            {
                prostorije = cuvanje.UcitajProstorije();
                foreach (Prostorija pros in prostorije)
                {
                    if (prostorija.id == pros.id)
                    {
                    
                        break;
                    }

                }

                prostorije.Add(prostorija);

            }
                cuvanje.Sacuvaj(prostorije);
            MessageBox.Show("Prostorije su azurirane!");
            this.Close();


        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            // Prostorija prostorija = new Prostorija();
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();
            foreach (Prostorija prostorija in prostorije)
            {
                if(Convert.ToInt32(Id.Text) == 0 )
                {
                    MessageBox.Show("Nemoguce izmeniti magacin!");
                    break;
                }
                if (Id.Text == prostorija.id)
                {
                    prostorija.sprat = Convert.ToInt32(Sprat.Text);
                    if (Sala.IsChecked == true)
                    {
                        var s = VrstaProstorije.Sala;
                        prostorija.vrsta = s;
                    }
                    else
           if (Soba.IsChecked == true)
                    {
                        prostorija.vrsta = VrstaProstorije.Soba;
                    }
                    else
            if (Kancelarija.IsChecked == true)
                    {
                        prostorija.vrsta = VrstaProstorije.Kancelarija;
                    }
                    else
                        prostorija.vrsta = VrstaProstorije.Ordinacija;

                }

            }
            cuvanje.Sacuvaj(prostorije);

            MessageBox.Show("Prostorije su azurirane!");
            this.Close();



        }
        private void obrisi(object sender, RoutedEventArgs e)
        {
            Prostorija p = (Prostorija)dgrProstorije.SelectedItems[0];
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = cuvanje.UcitajProstorije();
            foreach(Prostorija pros in prostorije)

            {
                if (Convert.ToInt32(Id.Text) == 0)
                {
                    MessageBox.Show("Nemoguce je obrisati magacin!");
                    break;
                }
                if (p.id == pros.id)
                {
                    prostorije.Remove(pros);
                    break;
                }

            }
            cuvanje.Sacuvaj(prostorije);

            MessageBox.Show("Prostorija je obrisana!");
            this.Close();
        }

        
    }
}

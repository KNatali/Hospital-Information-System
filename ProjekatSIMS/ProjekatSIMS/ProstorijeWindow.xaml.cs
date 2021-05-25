using Model;
using ProjekatSIMS.Service;
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
    
    public partial class ProstorijeWindow : Window
    {
        public ProstorijaService ProstorijaService { get; set; }
        public List<Prostorija> prostorije { get; set; }
        public ProstorijeWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ProstorijaService = new ProstorijaService();
            prostorije = new List<Prostorija>();
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();

            dgrProstorije.ItemsSource = prostorije;

        }
        private void dodaj(object sender, RoutedEventArgs e)
        {
            
            Prostorija novaProstorija = new Prostorija();
            novaProstorija.id = Id.Text;
            novaProstorija.sprat = Convert.ToInt32(Sprat.Text);
            novaProstorija.kvadratura = Convert.ToDouble(Kvadratura.Text);

            if (Sala.IsChecked == true)
            {
                var s = VrstaProstorije.Sala;
                novaProstorija.vrsta = s;
            }
            else
           if (Soba.IsChecked == true)
            {
                novaProstorija.vrsta = VrstaProstorije.Soba;
            }
            else
            if (Kancelarija.IsChecked == true)
            {
                novaProstorija.vrsta = VrstaProstorije.Kancelarija;
            }
            else
            if(Magacin.IsChecked == true)
            {
                novaProstorija.vrsta = VrstaProstorije.Magacin;
            }
            else
                novaProstorija.vrsta = VrstaProstorije.Ordinacija;

            novaProstorija.pregled = null;
            novaProstorija.inventar = null;
            novaProstorija.slobodna = true;

            if(ProstorijaService.pronadjiProstorijuPoId(novaProstorija.id) != null)
            {
                MessageBox.Show("Vec postoji prostorija sa istom oznakom!");
            }
            else
            {
                prostorije.Add(novaProstorija);
                ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);
                prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
                dgrProstorije.ItemsSource = prostorije;

            }

            
          


        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            
            
            foreach (Prostorija p in prostorije)
            {
                if(Convert.ToInt32(Id.Text) == 0 )
                {
                    MessageBox.Show("Nemoguce izmeniti glavni magacin!");
                    break;
                }
                if (Id.Text == p.id)
                {
                    p.sprat = Convert.ToInt32(Sprat.Text);
                    if (Sala.IsChecked == true)
                    {
                        var s = VrstaProstorije.Sala;
                        p.vrsta = s;
                    }
                    else
                     if (Soba.IsChecked == true)
                    {
                        p.vrsta = VrstaProstorije.Soba;
                    }
                    else
                    if (Kancelarija.IsChecked == true)
                    {
                        p.vrsta = VrstaProstorije.Kancelarija;
                    }
                    else
                    if (Magacin.IsChecked == true)
                    {
                        p.vrsta = VrstaProstorije.Magacin;
                    }
                    else
                        p.vrsta = VrstaProstorije.Ordinacija;

                    p.kvadratura = Convert.ToDouble(Kvadratura.Text);
                    MessageBox.Show("Prostorije su azurirane!");
                    ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);
                    prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
                    dgrProstorije.ItemsSource = prostorije;
                    
                    break;

                }

            }
            

            

        }
        private void obrisi(object sender, RoutedEventArgs e)
        {
            
            
            
            Prostorija prostorijaZaBrisanje = (Prostorija)dgrProstorije.SelectedItems[0];
            foreach(Prostorija p in prostorije)

            {
                if (Id.Text == "0")
                {
                    MessageBox.Show("Nemoguce je obrisati glavni magacin!");
                    break;
                }
                if (p.id == prostorijaZaBrisanje.id)
                {
                    prostorije.Remove(p);
                    break;
                }

            }

            MessageBox.Show("Prostorija je obrisana!");
            ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            dgrProstorije.ItemsSource = prostorije;

        }

        private void pregledajInventar(object sender, RoutedEventArgs e)
        {
            
            Prostorija p = (Prostorija)dgrProstorije.SelectedItems[0];
            if(Convert.ToInt32(p.id) == 0)
            {
                DinamickaOpremaWindow din = new DinamickaOpremaWindow();
                din.ShowDialog();
            }
            else
            {
                StatickaOpremaWindow st = new StatickaOpremaWindow(p);
                st.ShowDialog();
            }
            
        }

        
    }
}

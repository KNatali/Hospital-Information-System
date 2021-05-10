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
    
    public partial class ProstorijeWindow : Window
    {
        
        public ProstorijeWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();
           // ProstorijaRepository prostorijaRepository = new ProstorijaRepository(@"..\..\Fajlovi\Prostorije.txt");

           // prostorijaRepository.prostorije = prostorijaRepository.DobaviSveProstorije();
           // dgrProstorije.ItemsSource = prostorijaRepository.prostorije;
           dgrProstorije.ItemsSource = prostorije;

        }
        private void dodaj(object sender, RoutedEventArgs e)
        {
            /*
            Prostorija prostorija = new Prostorija();
            prostorija.id = Id.Text;
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
            if(Magacin.IsChecked == true)
            {
                prostorija.vrsta = VrstaProstorije.Magacin;
            }
            else
                prostorija.vrsta = VrstaProstorije.Ordinacija;

            prostorija.pregled = null;
            prostorija.inventar = null;
            prostorija.slobodna = true;

            ProstorijaRepository prostorijaRepository = new ProstorijaRepository(@"..\..\Fajlovi\Prostorije.txt");


            if (prostorijaRepository.dodajProstoriju(prostorija) == false)
            {
                MessageBox.Show("Vec postoji prostorija sa datim ID!");
            }
            else
            {
                MessageBox.Show("Prostorije su azurirane!");
                this.Close();
            }*/
            
            
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            Prostorija prostorija = new Prostorija();
            prostorija.id = Id.Text;
            prostorija.sprat = Convert.ToInt32(Sprat.Text);
            int flag = 0;
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
            if (Magacin.IsChecked == true)
            {
                prostorija.vrsta = VrstaProstorije.Magacin;
            }
            else
                prostorija.vrsta = VrstaProstorije.Ordinacija;

            prostorija.kvadratura = Convert.ToDouble(Kvadratura.Text);

            prostorija.pregled = null;
            prostorija.inventar = null;
            prostorija.slobodna = true;

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
                        MessageBox.Show("Vec postoji prostorija sa istom oznakom!");
                        flag = 1;
                        break;
                    }

                }
                if (flag == 0) {
                    prostorije.Add(prostorija);
                }
                

            }
                cuvanje.Sacuvaj(prostorije);
            MessageBox.Show("Prostorije su azurirane!");
            this.Close();


        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            /*
            ProstorijaRepository prostorijaRepository = new ProstorijaRepository(@"..\..\Fajlovi\Prostorije.txt");
            Prostorija p = (Prostorija)dgrProstorije.SelectedItems[0];
            p.sprat = Sprat.Text;
            p.kvadratura = Convert.ToDouble(Kvadratura.Text);
            */
            
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            // Prostorija prostorija = new Prostorija();
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();
            foreach (Prostorija prostorija in prostorije)
            {
                if(Convert.ToInt32(Id.Text) == 0 )
                {
                    MessageBox.Show("Nemoguce izmeniti glavni magacin!");
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
                    if (Magacin.IsChecked == true)
                    {
                        prostorija.vrsta = VrstaProstorije.Magacin;
                    }
                    else
                        prostorija.vrsta = VrstaProstorije.Ordinacija;

                    prostorija.kvadratura = Convert.ToDouble(Kvadratura.Text);
                    cuvanje.Sacuvaj(prostorije);

                    MessageBox.Show("Prostorije su azurirane!");
                    break;

                }

            }
            
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
                    MessageBox.Show("Nemoguce je obrisati glavni magacin!");
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

        private void Button_Click(object sender, RoutedEventArgs e)
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

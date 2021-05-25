using Model;
using ProjekatSIMS.Service;
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
    
    
    public partial class NaprednoRenoviranje : Window
    {
        public List<Prostorija> prostorije { get; set; }
        public ProstorijaService ProstorijaService = new ProstorijaService();
        public List<Prostorija> prostorijeZaSpajanje { get; set; }
        public List<Prostorija> razdeljeneProstorije { get; set; }
        public NaprednoRenoviranje()
        {
            InitializeComponent();
            this.DataContext = this;

            prostorije = new List<Prostorija>();
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            prostorijeZaSpajanje = new List<Prostorija>();
            razdeljeneProstorije = new List<Prostorija>();

            ProstorijeZaSpajanje.ItemsSource = prostorijeZaSpajanje;
            RazdeljeneProstorije.ItemsSource = razdeljeneProstorije;

        }

        private void obrisiProstorijuZaSpajanje(object sender, RoutedEventArgs e)
        {
            Prostorija prostorijaZaBrisanje = (Prostorija)Prostorije.SelectedItem;
            foreach (Prostorija p in prostorijeZaSpajanje)
            {
                if (p.id == prostorijaZaBrisanje.id)
                {
                    prostorijeZaSpajanje.Remove(p);
                    MessageBox.Show("Uspesno ste obrisali prostoriju iz liste za spajanje!");

                    ProstorijeZaSpajanje.ItemsSource = prostorijeZaSpajanje;
                }
            }
        }
        private void dodajProstorijuZaSpajanje(object sender, RoutedEventArgs e)
        {
            Prostorija prostorijaZaSpajanje = (Prostorija)Prostorije.SelectedItem;
            Boolean greska = false;
            if(prostorijeZaSpajanje == null)
            {
                prostorijeZaSpajanje.Add(prostorijaZaSpajanje);
                MessageBox.Show("Uspesno ste dodali prostoriju!");
                ProstorijeZaSpajanje.ItemsSource = prostorijeZaSpajanje;
               
            }
            else
            {
                foreach(Prostorija p in prostorijeZaSpajanje)
                {
                    if(p.id == prostorijaZaSpajanje.id)
                    {
                        MessageBox.Show("Prostorija vec dodata!");
                        greska = true;
                        break;
                    }

                }
                if(greska == false)
                {
                    prostorijeZaSpajanje.Add(prostorijaZaSpajanje);

                    MessageBox.Show("Uspesno ste dodali prostoriju!");
                    ProstorijeZaSpajanje.ItemsSource = prostorijeZaSpajanje;
                }

            }

        }


        private void dodajNovuProstoriju(object sender, RoutedEventArgs e)
        {
            Boolean greska = false;
            Prostorija novaProstorija = new Prostorija();
            novaProstorija.id = ID.Text;
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
            if (Magacin.IsChecked == true)
            {
                novaProstorija.vrsta = VrstaProstorije.Magacin;
            }
            else
                novaProstorija.vrsta = VrstaProstorije.Ordinacija;

            novaProstorija.kvadratura = Convert.ToDouble(Kvadratura.Text);


            foreach (Prostorija p in razdeljeneProstorije)
            {
                if(p.id == novaProstorija.id)
                {
                    MessageBox.Show("Vec postoji prostorija sa datim id!");
                    greska = true;
                    break;
                }
            }
            if(ProstorijaService.pronadjiProstorijuPoId(novaProstorija.id) == null)
            {
                MessageBox.Show("Uspesno ste dodali prostoriju!");
                razdeljeneProstorije.Add(novaProstorija);
                RazdeljeneProstorije.ItemsSource = razdeljeneProstorije;
            }


        }


    }
}

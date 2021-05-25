using Model;
using ProjekatSIMS.Service;
using Service;
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
        public ProstorijaService ProstorijaService = new ProstorijaService();
        public List<Prostorija> prostorije { get; set; }
        public InventarService InventarService = new InventarService();
        List<Inventar> dinamickaOprema { get; set; }
        public DinamickaOpremaWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            dinamickaOprema  = new List<Inventar>();
                        
            prostorije = new List<Prostorija>();
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            dinamickaOprema = InventarService.inventarRepository.DobaviInventarIzProstorije("0");
            
            dgrDinamickaOprema.ItemsSource = dinamickaOprema;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            Inventar inventar = new Inventar();
            inventar.id = Convert.ToInt32(Id.Text);
            inventar.ime = Ime.Text;
            inventar.kolicina = Convert.ToInt32(Kolicina.Text);
            inventar.Staticka = false;



            if (InventarService.pronadjiInventarPoId(Convert.ToInt32(Id.Text)) == null)
            {
                dinamickaOprema.Add(inventar);

                MessageBox.Show("Inventar je azuriran.");
            }
            else
            {
                MessageBox.Show("Vec postoji inventar sa istom ID oznakom!");
            }

            foreach(Prostorija p in prostorije)
            {
                if(p.id == "0")
                {
                    p.inventar = dinamickaOprema;
                    break;
                }
            }
            ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);

            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();

            dinamickaOprema = InventarService.inventarRepository.DobaviInventarIzProstorije("0");
            dgrDinamickaOprema.ItemsSource = dinamickaOprema;


        }
        private void izmeni(object sender, RoutedEventArgs e)
        {

            Inventar inventar = new Inventar();
            inventar = (Inventar)dgrDinamickaOprema.SelectedItems[0];

            foreach (Prostorija p in prostorije)

            {
                if (p.id == "0")
                {
                    foreach (Inventar i in p.inventar)
                    {
                        if (i.id == inventar.id) //pronasli smo trazeni inventar
                        {
                            i.kolicina = Convert.ToInt32(Kolicina.Text);
                            MessageBox.Show("Inventar je rasporedjen!");
                            break;
                        }
                    }
                    break;
                }
            }
            ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();

            dinamickaOprema = InventarService.inventarRepository.DobaviInventarIzProstorije("0");
            dgrDinamickaOprema.ItemsSource = dinamickaOprema;


        }
        private void obrisi(object sender, RoutedEventArgs e)
        {
            
            Inventar inventarZaBrisanje = (Inventar)dgrDinamickaOprema.SelectedItems[0];

            foreach (Prostorija p in prostorije)

            {
                if (p.id == "0") 
                {
                    foreach (Inventar i in p.inventar)
                    {
                        if(i.id == inventarZaBrisanje.id) 
                        {
                            p.inventar.Remove(i);
                            MessageBox.Show("Uspesno obrisali inventar!");
                            break;

                        }
                    }
                }
            }
            ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();

            dinamickaOprema = InventarService.inventarRepository.DobaviInventarIzProstorije("0");
            dgrDinamickaOprema.ItemsSource = dinamickaOprema;


        }

        private void pretrazi(object sender, RoutedEventArgs e)
        {

            
            List<Inventar> noviInventar = new List<Inventar>();
            foreach(Inventar i in dinamickaOprema)
            {
              if(i.ime.Equals(Pretraga.Text, StringComparison.OrdinalIgnoreCase))
                {
                    noviInventar.Add(i);
                }
            }
            dgrDinamickaOprema.ItemsSource = noviInventar;

            
        }

        private void ponisti(object sender, RoutedEventArgs e)
        {
            
            Pretraga.Text = "";
            dgrDinamickaOprema.ItemsSource = dinamickaOprema;
        }
    }
}

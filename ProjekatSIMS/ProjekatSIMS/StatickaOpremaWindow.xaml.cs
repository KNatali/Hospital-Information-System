using Model;
using ProjekatSIMS.Service;
using Service;
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
        public InventarService InventarService = new InventarService();
        public ProstorijaService ProstorijaService = new ProstorijaService();
        public List<Prostorija> prostorije = new List<Prostorija>();
       public List<Inventar> statickiInventar = new List<Inventar>();
        public StatickaOpremaWindow(Prostorija prosledjenaProstorija)
        {
            InitializeComponent();
            this.DataContext = this;
            prostorija = prosledjenaProstorija;
            List<Inventar> statickiInventar = new List<Inventar>();
            statickiInventar = InventarService.inventarRepository.DobaviInventarIzProstorije(prostorija.id);
            prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            

            dgrStatickaOprema.ItemsSource = statickiInventar;
        
            Prostorije.ItemsSource = prostorije;
        }


        private void rasporediInventar(object sender, RoutedEventArgs e)
        {
            /*
          Inventar inventar = (Inventar)dgrStatickaOprema.SelectedItems[0];
            Prostorija p = (Prostorija)Prostorije.SelectedItem;
            DateTime datum = (DateTime)Datum.SelectedDate;
            Double sati = Convert.ToDouble(Sati.Text);
            Double minuti = Convert.ToDouble(Minuti.Text);

            DateTime date = datum.AddHours(sati);
            date = date.AddMinutes(minuti);

            DateTime now = DateTime.Now;
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();

            int res = DateTime.Compare(now, date);
            if (res < 0)
            {
                while (true)
                {
                    if (DateTime.Compare(now, date) == 0)
                    {
                        foreach (Prostorija pros in prostorije)
                        {
                            if (pros.id == prostorija.id)
                            {
                                foreach (Inventar i in pros.inventar)
                                {
                                    if (i.id == inventar.id)
                                    {
                                        pros.inventar.Remove(i);
                                        break;
                                    }

                                }
                                break;
                            }
                        }
                        foreach (Prostorija pros in prostorije)
                        {

                            if (p.id == pros.id)

                            {
                                pros.inventar.Add(inventar);
                                break;

                            }
                        }
                        break;


                    }
                }
                cuvanje.Sacuvaj(prostorije);
                MessageBox.Show("Inventar je rasporedjen po zakazanom terminu!");
                this.Close();

            }
            else
            { 
                MessageBox.Show("Izabrali ste pogresan datum!");
                
            }
            
            */
        }

        private void dodajInventar(object sender, RoutedEventArgs e)
        {
            Inventar inventar = new Inventar();
            inventar.id = Convert.ToInt32(Id.Text);
            inventar.ime = Ime.Text;
            inventar.kolicina = 1;
            inventar.prostorija = prostorija.id;
            if (InventarService.pronadjiInventarPoId(Convert.ToInt32(Id.Text)) == null)
            {
                foreach (Prostorija p in prostorije)
                {
                    if (prostorija.id == p.id)
                    {
                        p.inventar.Add(inventar);

                        MessageBox.Show("Inventar je dodat!");
                        ProstorijaService.prostorijaRepository.Sacuvaj(prostorije);
                        prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
                        statickiInventar = InventarService.inventarRepository.DobaviInventarIzProstorije(p.id);
                        dgrStatickaOprema.ItemsSource = statickiInventar;
                        break;
                    }
                }

            }
            

            Id.Text = "";
            //Kolicina.Text = "";
            Ime.Text = "";
            
            
        }

        private void obrisiInventar(object sender, RoutedEventArgs e)
        {/*
            Inventar inventar = (Inventar)dgrStatickaOprema.SelectedItems[0];
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();

            foreach (Prostorija p in prostorije)
            {
                if (p.id == prostorija.id)
                {
                    foreach (Inventar i in p.inventar)
                    {
                        if (i.id == inventar.id) //pronasli smo trazeni inventar
                        {
                            p.inventar.Remove(i); //brisemo iz liste 
                            
                            break;


                        }


                    }
                    dgrStatickaOprema.ItemsSource = p.inventar;
                }

            }
            Id.Text = "";
            Kolicina.Text = "";
            Ime.Text = "";
            cuvanje.Sacuvaj(prostorije);
            MessageBox.Show("Inventar je obrisan!");
           */ 
        }

        private void ponistiFiltere(object sender, RoutedEventArgs e)
        {/*
            List<Inventar> oprema = new List<Inventar>();
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();


            foreach (Prostorija p in prostorije)
            {
                if (prostorija.id == p.id)
                {
                    oprema = p.inventar;
                }
            }
            dgrStatickaOprema.ItemsSource = oprema;
            Pretraga.Text = "";
        */}
        private void pretraziInventar(object sender, RoutedEventArgs e)
        {/*
            
            List<Inventar> noviInventar = new List<Inventar>();
            foreach(Inventar i in prostorija.inventar)
            {
                if(i.ime == Pretraga.Text)
                {
                    noviInventar.Add(i);
                }
            }
            dgrStatickaOprema.ItemsSource = noviInventar;
            */
        }

    }
}
    


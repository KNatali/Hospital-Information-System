using Model;
using Model.DoktorModel;
using Model.PacijentModel;
using Model.UpravnikModel;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS.Model.DoktorModel
{
   
    public partial class ZakaziOperaciju : Window
    {
        public List<Prostorija> Sale { get; set; }
        public ZakaziOperaciju()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Prostorija> prostorije = new List<Prostorija>();
            Sale = new List<Prostorija>();
            //ucitavanje sala u combobox
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Prostorija.txt"))
            {
                string json = r.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);

            }
            //ubacujem samo sale za operaciju
            foreach (Prostorija p in prostorije)
            {
                if (p.Vrsta == VrstaProstorije.Sala)
                    Sale.Add(p);
               
            }

            ///probaa sa listama sala
           
        }

        private void ZakazivanjOperacije(object sender, RoutedEventArgs e)
        {
            //prikupljam polja iz forme

            Pregled p = new Pregled();
            String jmbg = Jmbg.Text;
            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble( Termin.Text.Split(":")[0]);
            double minuti = Convert.ToDouble(Termin.Text.Split(":")[1]);
            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);


            //gledam da li postoji dati pacijent
            List<Pacijent> pacijenti = new List<Pacijent>();
            int znak = 0;

            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            foreach(Pacijent pa in pacijenti)
            {
                if (pa.Jmbg == jmbg)
                {
                    znak++;
                    p.pacijent = pa;
                    break;
                }
            }
            if (znak == 0)
            {
                MessageBox.Show("Pacijent nije nadjen!");
                return;
            }


          

            //FALI DA SE FINO NAMJESTI PACIJENT I DOKTOR I TRAJANJEE!!!!!!!!!
            p.Pocetak = datum1;
           
            p.Tip = TipPregleda.Operacija;
            p.StatusPregleda = StatusPregleda.Zakazan ;
            p.prostorija = (Prostorija)Sala.SelectedItem;
            
            Doktor dr = new Doktor { Jmbg = "1511990855023", Ime = "Marijana", Prezime = "Peric" };
            p.doktor = dr;


            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.UcitajSvePreglede();
            if (pregledi.Count == 0)
            {
                p.Id = 1;
            }
            else
            {
                p.Id = pregledi[pregledi.Count - 1].Id+1;
            }
            pregledi.Add(p);
            fajl.Sacuvaj(pregledi);

            MessageBox.Show("Uspjesno je zakazan termin");
            this.Close();
        }

        private void PrikazTermina(object sender, RoutedEventArgs e)
        {

            Termin.Items.Clear(); //cistim prethodno prikazane termine ako se predomisli pri izboru datuma
           
            DateTime datum = (DateTime)Date.SelectedDate;
            Prostorija sala = (Prostorija)Sala.SelectedItem;
            List<String> lista = new List<String>{ "9:0", "10:0", "11:0", "12:0","13:0","14:0","15:0"};
            List<String> zauzeto = new List<String>();
           
            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.UcitajSvePreglede();
           
            foreach(Pregled p in pregledi)
            {
              
                if (p.Pocetak.Year==datum.Year && p.Pocetak.Month == datum.Month && p.Pocetak.Day == datum.Day)
                {
                    if(p.doktor.Jmbg== "1511990855023")
                    {
                        zauzeto.Add(p.Pocetak.Hour.ToString() + ":" + p.Pocetak.Minute.ToString());
                    }
                    else
                    {
                        if (sala.Id == p.prostorija.Id)
                        {
                            zauzeto.Add(p.Pocetak.Hour.ToString() + ":" + p.Pocetak.Minute.ToString());
                        }
                    }
                    
                   
                }
            }
            /*idem kroz sve preglede,gledam da li se slaze sa datumom,ako je doktor isti,zauzet je taj
             * termin tog pregleda, ako nije isti doktor onda se gleda da li je ista sala kao odabrana,
             * ako jeste i taj termin se zauzima jer je sala zauzeta*/
            
            
            foreach(String i in lista)
            {
                if (zauzeto.Count==0)
                {
                    Termin.Items.Add(i);
                    
                }
                else
                {
                   
                    if (!zauzeto.Contains(i))
                        Termin.Items.Add(i);
                }
            }
           

        }

        

        private void PrikazInventara(object sender, RoutedEventArgs e)
        {
            RightListBox.Items.Clear();
            Prostorija s = (Prostorija)Sala.SelectedItem;
            
            ArrayList inventari = s.GetInventar();
            if(inventari.Count==0)
                RightListBox.Items.Add("Inventar jos nije unesen!");
            else
            {
                foreach (var i in inventari)
                    RightListBox.Items.Add(i.ToString());
               

            }
          
        }
    }
}


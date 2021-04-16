using Model;
using Model.DoktorModel;
using Model.PacijentModel;
using Model.UpravnikModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
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
   
    public partial class ZakaziPregled : Window   
    {
        public List<Prostorija> Ordinacije { get; set; }
        public ZakaziPregled()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Prostorija> prostorije = new List<Prostorija>();
            Ordinacije = new List<Prostorija>();
            //ucitavanje ordinacija u combobox
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Prostorija.txt"))
            {
                string json = r.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);
                
            }
            foreach(Prostorija p in prostorije)
            {
                if (p.Vrsta == VrstaProstorije.Ordinacija)
                    Ordinacije.Add(p);
            }

        }

        private void ZakazivanjePregleda(object sender, RoutedEventArgs e)
        {
            //prikupljam polja iz forme

            Pregled p = new Pregled();
            String jmbg = Jmbg.Text;
            DateTime datum = (DateTime)Date.SelectedDate;

            double sat;
            double minut;

            if (Termin.Visibility == Visibility.Visible)
            {
               sat = Convert.ToDouble(Termin.Text.Split(":")[0]);
               minut = Convert.ToDouble(Termin.Text.Split(":")[1]);
            }
            else
            {
                sat = Convert.ToDouble(Sat.Text);
                minut = Convert.ToDouble(Minut.Text);
            }
           
            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut);
            DateTime datum2 = datum1.AddMinutes(20);


            //gledam da li postoji dati pacijent
  
            List < Pacijent > pacijenti = new List<Pacijent>();
            int znak = 0;

            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            foreach (Pacijent pa in pacijenti)
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


            ///DATUMMM i VRIJEMEE
            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.UcitajSvePreglede();

            foreach (Pregled pr in pregledi)
            {
             
                if (pr.Pocetak.Year == datum1.Year && pr.Pocetak.Month == datum1.Month && pr.Pocetak.Day == datum1.Day)
                {
            
                    DateTime datum11 = pr.Pocetak;
                    DateTime datum22 = pr.Pocetak.AddMinutes(pr.Trajanje);
                    if (DateTime.Compare(datum1, datum11) >= 0 && DateTime.Compare(datum1, datum22) < 0 ||
                        DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) <= 0)
                    {
                        MessageBox.Show("Dati termin je zauzet");
                        PrikazTermina(pregledi,datum1,datum2);
                        return;
                    }
                
                }
            }


            p.Pocetak = datum1;
            p.Trajanje = 20;

            p.Tip = TipPregleda.Standardni;
            p.StatusPregleda = StatusPregleda.Zakazan;
            p.prostorija = (Prostorija)Ordinacija.SelectedItem;

            Doktor dr = new Doktor { Jmbg = "1511990855023", Ime = "Marijana", Prezime = "Peric" };
            p.doktor = dr;


         
            if (pregledi.Count == 0)
            {
                p.Id = 1;
            }
            else
            {
                p.Id = pregledi[pregledi.Count - 1].Id + 1;
            }
            pregledi.Add(p);
            fajl.Sacuvaj(pregledi);

            MessageBox.Show("Uspjesno je zakazan pregled");
            this.Close();
        }

            private void PrikazTermina(List<Pregled> pregledi,DateTime datum1,DateTime datum2)
            {
                 Termin.Visibility =Visibility.Visible;
                Izbor.Visibility = Visibility.Visible;
            List<Pregled> isti = new List<Pregled>();
                List<DateTime> termini = new List<DateTime>();
                DateTime pocetni = new DateTime(datum1.Year, datum1.Month, datum1.Day, 8, 0,0);
                DateTime krajnji = new DateTime(datum2.Year, datum2.Month, datum2.Day, 20, 0, 0);
                foreach (Pregled p in pregledi)
                {

                    if (p.Pocetak.Year == datum1.Year && p.Pocetak.Month == datum1.Month && p.Pocetak.Day == datum1.Day)
                    {
                    isti.Add(p);
                    }

                }
                for(DateTime i1 = pocetni; i1 < krajnji; i1 = i1.AddMinutes(20))
                {
                    int znak = 0;
                    DateTime i2 = i1.AddMinutes(20);
                    foreach(Pregled p in isti)
                    {
                        DateTime datum11 = p.Pocetak;
                        DateTime datum22 = p.Pocetak.AddMinutes(p.Trajanje);
                        if (DateTime.Compare(i1, datum11) >= 0 && DateTime.Compare(i1, datum22) < 0 ||
                            DateTime.Compare(i2, datum11) > 0 && DateTime.Compare(i2, datum22) <= 0)
                        {
                            znak++;
                        }
                    }
                    if (znak == 0)
                    {
                    Termin.Items.Add(i1.Hour.ToString()+":"+ i1.Minute.ToString());
                        
                    }
                }
                
            }

        
    }
}

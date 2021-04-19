using Model;
using Newtonsoft.Json;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for IzdajReceptDoktor.xaml
    /// </summary>
    public partial class IzdajReceptDoktor : Page
    {
        public List<Lijek> Lijekovi { get; set; }
        public Pacijent Pacijent { get; set; }
        public IzdajReceptDoktor(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijent = p;
            Ime.Text = p.Ime;
            Prezime.Text = p.Prezime;
           

            List<Lijek> lijekovi = new List<Lijek>();
            Lijekovi = new List<Lijek>();
            //ucitavanje lijekova u combobox
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Lijek.txt"))
            {
                string json = r.ReadToEnd();
                lijekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);

            }
          
            foreach (Lijek l in lijekovi)
            {
                Lijekovi.Add(l);

            }


        }

        private void IzdavanjeRecepta(object sender, RoutedEventArgs e)
        {
            Recept r = new Recept();
            DateTime datum =(DateTime) Datum.SelectedDate;
            DateTime datum1 = new DateTime();

           double sat = Convert.ToDouble(Sat.Text);
            double minut = Convert.ToDouble(Minut.Text);
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut);
            r.DatumPropisivanjaLeka = datum1;
            r.Kolicina = Kolicina.Text;
            Lijek l = new Lijek();
            l=(Lijek) Lijek.SelectedItem;

            List<String> alergeni = new List<String>();
            //provjera da li je pacijent alergican na to
            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();

            using (StreamReader sr = new StreamReader(@"..\..\..\Fajlovi\ZdravstveniKarton.txt"))
            {
                string json =sr.ReadToEnd();
                kartoni = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            ZdravsteniKarton zk = new ZdravsteniKarton();
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg == Pacijent.Jmbg)
                {
                    zk = k;
                    //a.zdravsteniKarton = k;
                    if (k.Alergeni == null)
                    
                        alergeni = new List<String>();
                    else
                    
                        alergeni = k.Alergeni;
                    
                }
            }
            if (l.Alergeni != null)
            {
                foreach (String s in l.Alergeni)
                {
                    if (alergeni.Contains(s))
                    {
                        MessageBox.Show("Pacijent je alergican na izabrani lijek. Izaberi novi!");
                        return;
                    }


                }
            }




            r.zdravsteniKarton = zk;
            r.NazivLeka = l.NazivLeka;
            String ucestalost = "";
            String u = "";
            if (Period.Text =="1")
            {
                ucestalost = "svaki dan";

            }
            else if (Convert.ToDouble(Period.Text) < 5){
                ucestalost = "svaka " + Period.Text + " dana";
            }
            else
            {
                ucestalost = "svakih " + Period.Text + " dana";
            }
            u = "Terapija traje " + Trajanje.Text + " dana i lijek se uzima " + ucestalost;
            r.Uputstvo = u;


            List<Recept> recepti= new List<Recept>();

            using (StreamReader sr = new StreamReader(@"..\..\..\Fajlovi\Recept.txt"))
            {
                string json = sr.ReadToEnd();
                recepti = JsonConvert.DeserializeObject<List<Recept>>(json);
            }
            if (recepti == null)
            {
                recepti = new List<Recept>();
                
            }
            recepti.Add(r);

            string newJson = JsonConvert.SerializeObject(recepti);
            File.WriteAllText(@"..\..\..\Fajlovi\Recept.txt", newJson);

            MessageBox.Show("Uspjesno je izdat recept");
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(Pacijent);

            this.NavigationService.Navigate(z);

        }

    }
}

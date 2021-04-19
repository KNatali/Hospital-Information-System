using Controller;
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
    /// Interaction logic for ZakaziPregledDoktor.xaml
    /// </summary>
    public partial class ZakaziPregledDoktor : Page
    {
       
        public List<Prostorija> Ordinacije { get; set; }
        public ZakaziPregledDoktor()
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
            foreach (Prostorija p in prostorije)
            {
                if (p.vrsta == VrstaProstorije.Ordinacija)
                    Ordinacije.Add(p);

            }
        }

        private void ZakazivanjePregleda(object sender, RoutedEventArgs e)
        {

            //prikupljam polja iz forme
            String jmbg = Jmbg.Text;
            Prostorija prostorija = (Prostorija)Ordinacija.SelectedItem;
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


            PregledController pc = new PregledController();

            if (pc.ZakazivanjePregleda(Termin, jmbg, prostorija, datum1, datum2) == true)
            {
                MessageBox.Show("Uspjesno je zakazan pregled");
                this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Neuspjesno zakazan termin!");
            }
        }
    
    }
}

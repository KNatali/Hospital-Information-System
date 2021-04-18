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
    /// Interaction logic for PrikazPregledaDoktor.xaml
    /// </summary>
    public partial class PrikazPregledaDoktor : Page
    {
       
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazPregledaDoktor()
        {
            
            InitializeComponent();
            this.DataContext = this;



            List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pregled.txt"))
            {
                string json = r.ReadToEnd();
                 pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            foreach(Pregled p in pregledi)
            {
                if (p.doktor.Jmbg== "1511990855023" && p.StatusPregleda==StatusPregleda.Zakazan)
                {
                    Pregledi.Add(p);
                }
            }
            

            pregledController = (Application.Current as App).PregledController;
        }

        private void OtkaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0]; //selektovani red
            if (pregledController.OtkazivanjePregledaDoktor(p))
            {
                MessageBox.Show("Uspjesno ste otkazali pregled");
            }
            else
                MessageBox.Show("Neuspjesno otkazvanje pregleda");

            PrikazPregledaDoktor pd = new PrikazPregledaDoktor();
            this.NavigationService.Navigate(pd);

        }

        private void IzmijeniPregled(object sender, RoutedEventArgs e)
        {

            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            PomjeriPregledDoktor po = new PomjeriPregledDoktor(p);
           // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(po);


        }

        private void PrikazProfila(object sender, RoutedEventArgs e)
        {

            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];

            ZdravstveniKartonDoktor z= new ZdravstveniKartonDoktor(p.pacijent);
            // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(z);


        }

        private void ZapocniPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            IzvrsavanjePregledaDoktor i= new IzvrsavanjePregledaDoktor(p);
            // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(i);


        }
        private PregledController pregledController;
    }
}

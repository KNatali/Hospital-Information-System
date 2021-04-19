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
    /// Interaction logic for PrikazZavrsenihPregleda.xaml
    /// </summary>
    public partial class PrikazZavrsenihPregleda : Page
    {
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazZavrsenihPregleda()
        {
            InitializeComponent();
            this.DataContext = this;



            List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Pregled.txt"))
            {
                string json = r.ReadToEnd();
                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            foreach (Pregled p in pregledi)
            {
                if (p.doktor.Jmbg == "1511990855023" && p.StatusPregleda == StatusPregleda.Zavrsen)
                {
                    Pregledi.Add(p);
                }
            }


           
        }

        private void PrikazProfila(object sender, RoutedEventArgs e)
        {

            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];

            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(p.pacijent);
            // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(z);


        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PrikazRecepataDoktor.xaml
    /// </summary>
    public partial class PrikazRecepataDoktor : Page {

        public List<Recept> Recepti { get; set; }
        public Pacijent pacijent { get; set; }
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
    
        
        public PrikazRecepataDoktor(Pacijent p)
        {


            InitializeComponent();
            this.DataContext = this;
            Recepti = new List<Recept>();
            pacijent = p;
            List<Recept> recepti;
            /*ReceptRepository receptRepository = new ReceptRepository(@"..\..\..\Fajlovi\Recept.txt");
            if (receptRepository.DobaviSveRecepte() != null)
            {
                recepti = receptRepository.DobaviSveRecepte();
            }
            foreach(Recept r in recepti)
            {
                if (r.zdravsteniKarton.pacijent.Jmbg == p.Jmbg)
                    Recepti.Add(r);
            }*/
            ZdravsteniKarton zdravstveniKarton=zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            if (zdravstveniKarton.Recepti == null)
                recepti = new List<Recept>();
            else
                recepti = zdravstveniKarton.Recepti;
            foreach (Recept r in recepti)
                Recepti.Add(r);



        }

        private void ZdravstveniKarton(object sender, RoutedEventArgs e)
        {
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
            // this.NavigationService.Navigate(new Uri("ZdravstveniKartonDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(z);
        }
    }
}

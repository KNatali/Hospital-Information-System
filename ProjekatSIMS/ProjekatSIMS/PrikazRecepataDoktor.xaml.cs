using Model;
using Repository;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{

    public partial class PrikazRecepataDoktor : Page
    {

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
            ZdravsteniKarton zdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            if (zdravstveniKarton.Recepti == null)
                recepti = new List<Recept>();
            else
                recepti = zdravstveniKarton.Recepti;
            foreach (Recept r in recepti)
                Recepti.Add(r);

        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
            this.NavigationService.Navigate(z);
        }
    }
}

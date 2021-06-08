using Model;
using Repository;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{

    public partial class PrikazZavrsenihPregleda : Page
    {
        private DoktorRepository doktorRepository = new DoktorRepository();
        private PregledRepository pregledRepository = new PregledRepository();
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazZavrsenihPregleda()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Doktor> doktori = doktorRepository.DobaviSve();
            Doktor doktor = new Doktor();
            foreach (Doktor d in doktori)
            {
                if (d.Jmbg == "1511990855023")
                {
                    doktor = d;
                    break;
                }
            }
            Pregledi = pregledRepository.DobaviZakazanePregledeDoktora(doktor);

        }

        private void PrikazProfila(object sender, RoutedEventArgs e)
        {

            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];

            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(p.pacijent);
            this.NavigationService.Navigate(z);


        }
    }
}

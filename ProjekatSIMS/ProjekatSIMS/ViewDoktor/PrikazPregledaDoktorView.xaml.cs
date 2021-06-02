using Controller;
using Model;
using ProjekatSIMS.ViewModelDoktor;
using Repository;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.ViewDoktor
{

    public partial class PrikazPregledaDoktorView : Page
    {
        private DoktorRepository doktorRepository = new DoktorRepository();
        private PregledRepository pregledRepository = new PregledRepository();
        private OtkazivanjePregledaDoktorController otkazivanjePregledaDoktorController = new OtkazivanjePregledaDoktorController();
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazPregledaDoktorView(PrikazPregledaDoktorViewModel viewModel)
        {

            InitializeComponent();
            this.DataContext = viewModel;
           /* List<Doktor> doktori = doktorRepository.DobaviSve();
            Doktor doktor = new Doktor();
            foreach (Doktor d in doktori)
            {
                if (d.Jmbg == "1511990855023")
                {
                    doktor = d;
                    break; 
                }
            }
            Pregledi = pregledRepository.DobaviZakazanePregledeDoktora(doktor);*/

        }

        /*private void DetaljiPregleda(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            DetaljiPregledaDoktor d = new DetaljiPregledaDoktor(p);
            this.Opacity = 0.3;
            d.ShowDialog();
            this.Opacity = 1;

         }*/

        private void OtkaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            otkazivanjePregledaDoktorController.OtkazivanjePregleda(p);
             MessageBox.Show("Uspjesno ste otkazali pregled");
           

            //PrikazPregledaDoktor pd = new PrikazPregledaDoktor();
           // this.NavigationService.Navigate(pd);

        }

        private void IzmijeniPregled(object sender, RoutedEventArgs e)
        {

            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            PomjeriPregledDoktor po = new PomjeriPregledDoktor(p);
            this.NavigationService.Navigate(po);


        }

        private void PrikazProfila(object sender, RoutedEventArgs e)
        {

            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];

            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(p.pacijent);
             this.NavigationService.Navigate(z);


        }

        private void ZapocniPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            IzvrsavanjePregledaDoktor i = new IzvrsavanjePregledaDoktor(p);
            this.NavigationService.Navigate(i);


        }
     
    }
}

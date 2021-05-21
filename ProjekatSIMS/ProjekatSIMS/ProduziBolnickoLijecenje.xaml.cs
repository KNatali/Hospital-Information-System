using Controller;
using Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for ProduziBolnickoLijecenje.xaml
    /// </summary>
    public partial class ProduziBolnickoLijecenje : Page
    {

        private ProduzenjeUputaBolnickoLijecenjeController produzenjeUputaController = new ProduzenjeUputaBolnickoLijecenjeController();
        private UputBolnickoLijecenje uputStari = new UputBolnickoLijecenje();
        private Pacijent pacijent = new Pacijent();

        public ProduziBolnickoLijecenje(UputBolnickoLijecenje uput, Pacijent p)
        {
            InitializeComponent();
            pacijent = p;

            uputStari = uput;
            IntervalPocetak.Text = uput.IntervalPocetak.ToString("dd/MM/yyyy");
            KrajInterval.SelectedDate = uput.IntervalKraj;
            Soba.Text = uput.SobaId;
            Krevet.Text = uput.KrevetId.ToString();

        }
        private void ProduziUput(object sender, RoutedEventArgs e)
        {

            if (produzenjeUputaController.IsProduzavanjeMoguce(uputStari, (DateTime)KrajInterval.SelectedDate))
            {
                produzenjeUputaController.ProduzavanjeUputa(uputStari, (DateTime)KrajInterval.SelectedDate, pacijent);
                MessageBox.Show("Uspjesno ste produzili period bolnickog lijecenja");
                PrikazUputaZaBolnickoLijecenje a = new PrikazUputaZaBolnickoLijecenje(pacijent);
                 this.NavigationService.Navigate(a);
            }

            else
                MessageBox.Show("Nije moguce produziti boravak do izabranog datuma");


        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}

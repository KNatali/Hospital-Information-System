using Controller;
using Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PrikazAnamneza.xaml
    /// </summary>
    public partial class PrikazAnamneza : Page
    {
        private PrikazAnamnezaZaPacijentaController prikazAnamnezaZaPacijentaController = new PrikazAnamnezaZaPacijentaController();
        public List<Anamneza> Anamneze { get; set; }
        public Pacijent pacijent { get; set; }
        public PrikazAnamneza(Pacijent p)
        {
            InitializeComponent();

            this.DataContext = this;
            pacijent = p;
            Anamneze = prikazAnamnezaZaPacijentaController.PrikazAnamneza(pacijent);

        }

        private void ZdravstveniKarton(object sender, RoutedEventArgs e)
        {
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
            this.NavigationService.Navigate(z);
        }

        private void AzuriranjeAnamneze(object sender, RoutedEventArgs e)
        {
            Anamneza an = (Anamneza)dataGridAnamneze.SelectedItem;
            AzuriranjeAnamnezeDoktor a = new AzuriranjeAnamnezeDoktor(pacijent, an);
            this.NavigationService.Navigate(a);
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {


            this.NavigationService.GoBack();
        }
    }
}

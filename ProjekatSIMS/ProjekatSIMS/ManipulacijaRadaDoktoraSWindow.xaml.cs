using Model;
using Repository;
using Controller;
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
using System.Windows.Shapes;
using ProjekatSIMS.Controller;

namespace ProjekatSIMS
{
    public partial class ManipulacijaRadaDoktoraSWindow : Window
    {
        private NeradniDaniController neradniDaniController;
        public Doktor doktor { get; set; }
        public List<NeradniDani> NeradniDani { get; set; }
        public ManipulacijaRadaDoktoraSWindow(Doktor d)
        {
            InitializeComponent();
            this.DataContext = this;
            doktor = d;
            List<NeradniDani> tabelaNeradnihDana = new List<NeradniDani>();
            NeradniDani = new List<NeradniDani>();
            Obrazlozenje.ItemsSource = Enum.GetValues(typeof(VrsteNeradnihDana));
            neradniDaniController = new NeradniDaniController();
            tabelaNeradnihDana = neradniDaniController.DobaviSve();
            foreach (NeradniDani n in tabelaNeradnihDana)
            {
                if (n.doktor.Jmbg == d.Jmbg)
                    NeradniDani.Add(n);
            }
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Odobri_neradneDane(object sender, RoutedEventArgs e)
        {
            NeradniDani novoOdobrenje = new NeradniDani();
            neradniDaniController = new NeradniDaniController();
            PopunjavanjePoljaZaGodisnjiOdmor(novoOdobrenje);
            if (neradniDaniController.OdobriNeradneDane(novoOdobrenje) == true)
            {
                MessageBox.Show("Doktoru su odobreni neradni dani.");
                this.Close();
            }
        }
        private void PopunjavanjePoljaZaGodisnjiOdmor(NeradniDani novoOdobrenje)
        {
            novoOdobrenje.NeradnoOd = (DateTime)Od.SelectedDate;
            novoOdobrenje.NeradnoDo = (DateTime)Do.SelectedDate;
            novoOdobrenje.Vrsta = (VrsteNeradnihDana)Obrazlozenje.SelectedIndex;
            novoOdobrenje.doktor = doktor;
        }
    }
}

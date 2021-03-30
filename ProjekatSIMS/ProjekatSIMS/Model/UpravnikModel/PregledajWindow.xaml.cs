using Model.UpravnikModel;
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

namespace ProjekatSIMS.Model.UpravnikModel
{
    public partial class PregledajWindow : Window
    {
        public List<Prostorija> prostorije { get; set; }
        public PregledajWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            prostorije = new List<Prostorija>();
            CuvanjeProstorija file = new CuvanjeProstorija(@"C:\Users\mzari\Desktop\Projekat\Projekat\ProjekatSIMS\Prostorije.txt");
            prostorije = file.UcitajProstorije();
        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {

            Prostorija p = (Prostorija)dataGridProstorije.SelectedItems[0];
            IzmeniWindow  izmeni = new IzmeniWindow(izmeni);
            izmeni.Show();

        }
        private void Obrisi(object sender, RoutedEventArgs e)
        {

            Prostorija p = (Prostorija)dataGridProstorije.SelectedItems[0];
            ObrisiWindow o = new ObrisiWindow(o);
            o.Show();

        }




    }
}

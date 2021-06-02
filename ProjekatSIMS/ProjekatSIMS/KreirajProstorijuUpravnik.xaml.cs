using ProjekatSIMS.Controller;
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
    public partial class KreirajProstorijuUpravnik : Page
    {

        public ProstorijaController ProstorijaController = new ProstorijaController();
        public KreirajProstorijuUpravnik()
        {
            InitializeComponent();

        }
        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            if (ProstorijaController.KreirajProstoriju(Id.Text, Vrsta.Text, Convert.ToInt32(Sprat.Text), Convert.ToDouble(Kvadratura.Text)))
            {
                MessageBox.Show("Uspesno ste kreirali prostoriju!");
            }
            else
                MessageBox.Show("Vec postoji prostorija sa datom sifrom!");
        }
    }
}

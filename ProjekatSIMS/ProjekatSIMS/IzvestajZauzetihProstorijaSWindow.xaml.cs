using Model;
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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    public partial class IzvestajZauzetihProstorijaSWindow : Window
    {
        private ProstorijaController prostorijaController;
        public List<Prostorija> Prostorije { get; set; }
        public IzvestajZauzetihProstorijaSWindow(DateTime datumOd, DateTime datumDo)
        {
            InitializeComponent();
            this.DataContext = this;
            List<Prostorija> listaProstorija = new List<Prostorija>();
            Prostorije = new List<Prostorija>();
            prostorijaController = new ProstorijaController();
            listaProstorija = prostorijaController.DobaviSve();
            foreach (Prostorija p in listaProstorija)
            {
                if (p.ZauzetaOd == datumOd && p.ZauzetaDo == datumDo)
                    Prostorije.Add(p);
            }
        }

        private void Stampanje(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Izveštaj se štampa u PDF formatu.","OBAVEŠTENJE");
            this.Close();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

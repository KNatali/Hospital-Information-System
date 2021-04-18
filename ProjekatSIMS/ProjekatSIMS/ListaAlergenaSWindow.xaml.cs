using Model;
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
    public partial class ListaAlergenaSWindow : Window
    {
        public List<ZdravsteniKarton> Karton { get; set; }
        public ListaAlergenaSWindow(Pacijent p)
        {
            InitializeComponent();
            /*this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            List<Pacijent> ListaPacijenata = new List<Pacijent>();
            CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\ZdravstveniKarton.txt");
            ListaPacijenata = fajl.DobaviPacijente();
            foreach (Pacijent p in ListaPacijenata)
            {
                if (p.Jmbg == jmbg)
                {
                    Pacijenti.Add(p);
                    pac = p;
                }
            }*/

        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Dodavanje(object sender, RoutedEventArgs e)
        {
            this.Close();
            NoviAlergenSWindow na = new NoviAlergenSWindow();
            na.Show();
        }
    }
}

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
    /// <summary>
    /// Interaction logic for TabelaPacijenataSWindow.xaml
    /// </summary>
    public partial class TabelaPacijenataSWindow : Window
    {
        public List<Pacijent> Pacijenti { get; set; }
        public TabelaPacijenataSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\Pacijent.txt");
            Pacijenti = fajl.DobaviPacijente();
        }
        private void Profil(object sender, RoutedEventArgs e)
        {
            this.Close();
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow();
            pp.Show();
        }
        private void Pretraga(object sender, RoutedEventArgs e)
        {
            this.Close();
            PretraziPacijenteSekretarWindow pp = new PretraziPacijenteSekretarWindow();
            pp.Show();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

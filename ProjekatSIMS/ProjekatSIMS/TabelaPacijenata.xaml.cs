using Model;
using Model.SekretarModel;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class TabelaPacijenata : Window
    {
        public CuvanjePacijenta fajl { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
        public TabelaPacijenata()
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\Pacijent.txt");
            Pacijenti = fajl.DobaviPacijente();
        }
        private void Brisanje(object sender, RoutedEventArgs e)
        {
            // selektuje nekog pacijenta u tabeli i onda klikne na brisanje
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            
            MessageBoxResult ret = MessageBox.Show("Da li zelite da obrisete pacijenta?", "Provera", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    if(p.ObrisiPacijent()==true)
                    {
                        MessageBox.Show("Pacijent je obrisan.", "Obavestenje");
                        this.Close();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Izmena_profila(object sender, RoutedEventArgs e)
        {
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            IzmenaProfilaWindow ip = new IzmenaProfilaWindow(p);
            ip.Show();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

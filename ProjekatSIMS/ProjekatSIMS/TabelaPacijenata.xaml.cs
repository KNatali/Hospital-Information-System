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
            CuvanjePacijenta fajl = new CuvanjePacijenta(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt");
            Pacijenti = fajl.DobaviPacijente();
        }
        private void Brisanje(object sender, RoutedEventArgs e)
        {
            // selektuje nekog pacijenta u tabeli i onda klikne na brisanje
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            string linija;
            List<String> linije = new List<string>();
            
            MessageBoxResult ret = MessageBox.Show("Da li zelite da obrisete pacijenta?", "Provera", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    using (StreamReader fajl = new StreamReader(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt"))
                    {
                        while ((linija = fajl.ReadLine()) != null)
                        {
                            string[] deo = linija.Split(",");
                            if (deo[5] != p.Jmbg.ToString())
                            {
                                linije.Add(linija);
                            }
                        }
                        fajl.Close();
                    }
                    File.WriteAllLinesAsync(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt", linije);
                    MessageBox.Show("Pacijent je obrisan.", "Obavestenje");
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Izmena_profila(object sender, RoutedEventArgs e)
        {
            IzmenaProfilaWindow ip = new IzmenaProfilaWindow();
            ip.Show();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

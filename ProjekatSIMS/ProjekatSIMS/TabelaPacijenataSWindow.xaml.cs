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
    public partial class TabelaPacijenataSWindow : Window
    {
        public CuvanjePacijenta fajl { get; set; }
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
            ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(p);
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
        private void Obrisi(object sender, RoutedEventArgs e)
        {
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];

            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete pacijenta?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    if (p.ObrisiPacijent() == true)
                    {
                        CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\Pacijent.txt");
                        List<Pacijent> pacijent = fajl.DobaviPacijente();
                        foreach (Pacijent pa in pacijent)
                        {
                            if (pa.Jmbg == p.Jmbg)
                            {
                                pacijent.Remove(pa);
                                break;
                            }
                        }
                        fajl.Sacuvaj(pacijent);
                        MessageBox.Show("Pacijent je uspešno obrisan.", "OBAVEŠTENJE");
                        this.Close();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

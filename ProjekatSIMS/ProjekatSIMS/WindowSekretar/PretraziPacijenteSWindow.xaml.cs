using System;
using Model;
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
using System.IO;
using Newtonsoft.Json;

namespace ProjekatSIMS
{
    public partial class PretraziPacijenteSWindow : Window
    {
        public PretraziPacijenteSWindow()
        {
            InitializeComponent();
            List<Pacijent> pacijenti = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            dataGridPacijenti.ItemsSource = pacijenti;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridPacijenti.ItemsSource);
            view.Filter = PretragaPoImePrezime;
        }
        private bool PretragaPoImePrezime(object pacijent)
        {
            if (PrazanTextBoxPretrage())
                return true;
            else
                return (PretragaImenaIzTextBoxa(pacijent) && PretragaPrezimenaIzTextBoxa(pacijent));
        }

        private bool PretragaPrezimenaIzTextBoxa(object pacijent)
        {
            return (pacijent as Pacijent).Prezime.IndexOf(Prezime.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool PretragaImenaIzTextBoxa(object pacijent)
        {
            return (pacijent as Pacijent).Ime.IndexOf(Ime.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool PrazanTextBoxPretrage()
        {
            return String.IsNullOrEmpty(Ime.Text) && String.IsNullOrEmpty(Prezime.Text);
        }

        private void refreshTabele(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridPacijenti.ItemsSource).Refresh();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(p);
            pp.Show();
            this.Close();
        }
    }
}

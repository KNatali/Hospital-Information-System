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
    public partial class PretraziDoktoreSWindow : Window
    {
        public PretraziDoktoreSWindow()
        {
            InitializeComponent();
            List<Doktor> doktori = new List<Doktor>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Doktor.txt"))
            {
                string json = r.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            dataGridDoktori.ItemsSource = doktori;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridDoktori.ItemsSource);
            view.Filter = PretragaPoImePrezime;
        }
        private bool PretragaPoImePrezime(object doktor)
        {
            if (PrazanTextBoxPretrage())
                return true;
            else
                return (PretragaImenaIzTextBoxa(doktor) && PretragaPrezimenaIzTextBoxa(doktor));
        }

        private bool PretragaPrezimenaIzTextBoxa(object doktor)
        {
            return (doktor as Doktor).Prezime.IndexOf(Prezime.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool PretragaImenaIzTextBoxa(object doktor)
        {
            return (doktor as Doktor).Ime.IndexOf(Ime.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool PrazanTextBoxPretrage()
        {
            return String.IsNullOrEmpty(Ime.Text) && String.IsNullOrEmpty(Prezime.Text);
        }

        private void refreshTabele(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridDoktori.ItemsSource).Refresh();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Doktor d = (Doktor)dataGridDoktori.SelectedItems[0];
            ProfilDoktoraSWindow pd = new ProfilDoktoraSWindow(d);
            pd.Show();
            this.Close();
        }
    }
}

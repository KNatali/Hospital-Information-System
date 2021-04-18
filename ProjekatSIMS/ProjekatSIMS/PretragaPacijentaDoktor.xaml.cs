using Model;
using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PretragaPacijentaDoktor.xaml
    /// </summary>
    public partial class PretragaPacijentaDoktor : Page
    {
        public PretragaPacijentaDoktor()
        {
            InitializeComponent();

            List<Pacijent> items = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }

            Pacijenti.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Pacijenti.ItemsSource);
            view.Filter = UserFilter;


            //probavanje tabele
            //Pacijenti1.ItemsSource = items;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(Filter.Text))
                return true;
            else
                return (((item as Pacijent).Ime + " " + (item as Pacijent).Prezime).IndexOf(Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ((item as Pacijent).Prezime + " " + (item as Pacijent).Ime).IndexOf(Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        (item as Pacijent).Jmbg.IndexOf(Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Pacijenti.ItemsSource).Refresh();
        }

        private void PrikazZdravstvenogKartona(object sender, RoutedEventArgs e)
        {

            if (Pacijenti.SelectedValue == null)
            {
                MessageBox.Show("Selektujte pacijenta prije klika na zdravstveni karton!");
                return;
            }
            Pacijent pacijent = (Pacijent)Pacijenti.SelectedItems[0];
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
            // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(z);
        }
    }
}

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
    /// Interaction logic for VerifikovaniLIjekoviDoktor.xaml
    /// </summary>
    public partial class VerifikovaniLIjekoviDoktor : Page
    {
        public VerifikovaniLIjekoviDoktor()
        {
            InitializeComponent();
        
            this.DataContext = this;
            List<Lijek> SviLijekovi = new List<Lijek>();
            List<Lijek> VerifikovaniLijekovi = new List<Lijek>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Lijek.txt"))
            {
                string json = r.ReadToEnd();
                SviLijekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);
            }
            foreach (Lijek l in SviLijekovi)
            {
                if (l.Status != OdobravanjeLekaEnum.Ceka)
                    VerifikovaniLijekovi.Add(l);
            }

            ListCollectionView collectionView = new ListCollectionView(VerifikovaniLijekovi);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Status"));


            dataGridVerifikovani.ItemsSource = collectionView;
        }

        private void PrikaziDetaljaLijeka(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikovani.SelectedItems[0];
            Opis.Text = lijek.Opis;
            List<String> sastojci = lijek.Alergeni;
            Sastojci.ItemsSource = sastojci;
        }

        
        private void IzmijeniLijek(object sender, RoutedEventArgs e)
        {
            Lijek lijek = (Lijek)dataGridVerifikovani.SelectedItems[0];
            IzmjenaLijekDoktor i = new IzmjenaLijekDoktor(lijek);
             this.NavigationService.Navigate(i);
        }
    }
}

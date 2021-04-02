using Model.UpravnikModel;
using Newtonsoft.Json;
using ProjekatSIMS.Model.DoktorModel;
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
    /// <summary>
    /// Interaction logic for DoktorWindow.xaml
    /// </summary>
    public partial class DoktorWindow : Window
    {
        public List<Prostorija> Sale { get; set; }
        public DoktorWindow()
        {
            InitializeComponent();
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            ZakaziPregled z = new ZakaziPregled();
            z.Show();

        }

        private void PrikazPregleda(object sender, RoutedEventArgs e)
        {
            PrikazPregleda p = new PrikazPregleda();
            p.Show();

        }

        //za dodavanje sale
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newJson = "";
            VrstaProstorije v = new VrstaProstorije();
            Prostorija sala = new Prostorija { Id = "A1", Sprat = 2 };
            sala.Vrsta=v.

            using (StreamReader r = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Prostorija.txt"))
            {
                string json = r.ReadToEnd();
                List<Prostorija> pregledi = JsonConvert.DeserializeObject<List<Prostorija>>(json);
                if (Sale == null)
                {
                    Sale = new List<Prostorija>();

                }
                pregledi.Add(pregled);
                newJson = JsonConvert.SerializeObject(pregledi);
            }

            File.WriteAllText(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt", newJson);
        }
    }
}

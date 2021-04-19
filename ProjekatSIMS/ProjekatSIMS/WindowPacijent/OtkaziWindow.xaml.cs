using Model;
using Newtonsoft.Json;
using Repository;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for OtkaziWindow.xaml
    /// </summary>
    public partial class OtkaziWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public OtkaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();
        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0]; //ovo je odabrani pregled za otkazivanje


            using (StreamReader file = new StreamReader(@"..\..\Fajlovi\Pregled.txt"))
            {

                Pregledi.Remove(p);

            }
            string newJson = JsonConvert.SerializeObject(Pregledi);
            File.WriteAllText(@"..\..\Fajlovi\Pregled.txt", newJson);
            MessageBox.Show("Vas pregled je otkazan.");
            this.Close();
            VidiWindow vw = new VidiWindow();
            vw.Show();





        }
    }
}

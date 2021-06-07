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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    public partial class NaplataPregledaSWindow : Window
    {
        public List<Doktor> Doktori { get; set; }
        public NaplataPregledaSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Doktor> doktori = new List<Doktor>();
            Doktori = new List<Doktor>();
            //ucitavanje doktora u combobox
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Doktor.txt"))
            {
                string json = r.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            foreach (Doktor d in doktori)
                Doktori.Add(d);
            Pregledi.ItemsSource = Enum.GetValues(typeof(TipPregleda));
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

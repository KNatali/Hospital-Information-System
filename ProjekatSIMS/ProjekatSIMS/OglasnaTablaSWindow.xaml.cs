using Model;
using Repository;
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
    public partial class OglasnaTablaSWindow : Window
    {
        public List<Notifikacija> Obavestenja { get; set; }
        public OglasnaTablaSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Obavestenja = new List<Notifikacija>();
            NotifikacijaRepository fajl = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");
            Obavestenja = fajl.DobaviNotifikacije();
        }
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Notifikacija n = (Notifikacija)dataGridObavestenja.SelectedItems[0];
            ObavestenjeSWindow o = new ObavestenjeSWindow(n);
            o.Show();
            this.Close();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Novo(object sender, RoutedEventArgs e)
        {
            NovaObjavaSWindow no = new NovaObjavaSWindow();
            no.Show();
            this.Close();
        }
    }
}

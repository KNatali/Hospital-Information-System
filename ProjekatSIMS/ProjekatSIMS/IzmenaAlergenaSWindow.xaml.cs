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
    /// <summary>
    /// Interaction logic for IzmenaAlergenaSWindow.xaml
    /// </summary>
    public partial class IzmenaAlergenaSWindow : Window
    {
        public List<ZdravsteniKarton> Karton { get; set; }
        public IzmenaAlergenaSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Karton = new List<ZdravsteniKarton>();
            List<String> alergeni = new List<String>();
            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();
            //Alergeni1 = new List<String>();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            List<Pregled> pregledi = new List<Pregled>();
            Karton = new List<ZdravsteniKarton>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\ZdravstveniKarton.txt");
            Karton = fajl.DobaviAlergene();
        }
    }
}

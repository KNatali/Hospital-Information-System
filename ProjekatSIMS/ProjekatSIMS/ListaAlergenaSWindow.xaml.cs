using Model;
using Newtonsoft.Json;
using Repository;
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
    public partial class ListaAlergenaSWindow : Window
    {
        public ZdravsteniKarton zdrkarton { get; set; }
        public List<ZdravsteniKarton> Karton { get; set; }
        public List<String> Ale { get; set; }
        public ListaAlergenaSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            List<String> al = new List<String>();
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\ZdravstveniKarton.txt");
            Karton = fajl.DobaviAlergene();
            foreach (ZdravsteniKarton z in Karton)
            {
                if (z.pacijent.Jmbg == p.Jmbg)
                {
                    al = z.Alergeni;
                }
            }
            MessageBox.Show(al.Count.ToString());

        }
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            //zdrkarton.Alergeni = Naziv.Text;
            this.Close();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Dodavanje(object sender, RoutedEventArgs e)
        {
            /*List<String> a = Naziv.ToString();
            Pacijent p = new Pacijent();
            ZdravsteniKarton z = new ZdravsteniKarton();
            z.Alergeni = a;*/
            this.Close();
            NoviAlergenSWindow na = new NoviAlergenSWindow();
            na.Show();
        }
    }
}

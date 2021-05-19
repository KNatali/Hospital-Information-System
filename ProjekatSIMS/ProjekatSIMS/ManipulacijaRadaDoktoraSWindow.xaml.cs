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
    public partial class ManipulacijaRadaDoktoraSWindow : Window
    {
        public Doktor dok { get; set; }
        public List<NeradniDani> Neradni { get; set; }
        public ManipulacijaRadaDoktoraSWindow(Doktor doktor)
        {
            InitializeComponent();
            this.DataContext = this;
            dok = doktor;
            Obrazlozenje.ItemsSource = Enum.GetValues(typeof(VrsteNeradnihDana));
            List<NeradniDani> neradniDani = new List<NeradniDani>();
            Neradni = new List<NeradniDani>();
            NeradniDaniRepository fajl = new NeradniDaniRepository(@"..\..\..\Fajlovi\NeradniDani.txt");
            neradniDani = fajl.DobaviNeradneDane();
            foreach (NeradniDani n in neradniDani)
            {
                if (n.doktor.Jmbg == doktor.Jmbg)
                {
                    Neradni.Add(n);
                }
            }
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            NeradniDani nd = new NeradniDani();
            nd.NeradnoOd = (DateTime)Od.SelectedDate;
            nd.NeradnoDo = (DateTime)Do.SelectedDate;
            nd.Vrsta = (VrsteNeradnihDana)Obrazlozenje.SelectedIndex;
            nd.doktor = dok;
             
            NeradniDaniRepository fajl = new NeradniDaniRepository(@"..\..\..\Fajlovi\NeradniDani.txt");
            List<NeradniDani> ListaDana = fajl.DobaviNeradneDane();
            ListaDana.Add(nd);
            fajl.SacuvajNeradanDan(ListaDana);
            dataGridNeradniDani.ItemsSource = ListaDana;
            //this.Close();
        }
    }
}

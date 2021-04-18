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
    public partial class KalendarPregledaSWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public KalendarPregledaSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\SviPregledi.txt");
            Pregledi = fajl.GetListaPregledaSekretar();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            IzmenaPregledaSWindow ip = new IzmenaPregledaSWindow(p);
            //IzmenaPregledaSWindow ip = new IzmenaPregledaSWindow();
            ip.Show();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete pregled?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    {
                        PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\SviPregledi.txt");
                        List<Pregled> pregled = fajl.GetListaPregledaSekretar();
                        foreach (Pregled pr in pregled)
                        {
                            if (pr.Id == p.Id)
                            {
                                pregled.Remove(pr);
                                break;
                            }
                        }
                        fajl.SacuvajPregledSekretar(pregled);
                        MessageBox.Show("Pregled je uspešno otkazan.", "OBAVEŠTENJE");
                        this.Close();
                        break;
                    }
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

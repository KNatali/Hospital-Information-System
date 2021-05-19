using Controller;
using Microsoft.Toolkit.Uwp.Notifications;
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
using Tulpep.NotificationWindow;

namespace ProjekatSIMS
{
    public partial class KalendarPregledaSWindow : Window
    {
        private PregledController pregledController;
        public List<Pregled> Pregledi { get; set; }
        public KalendarPregledaSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Pregled> tabelaPregleda = new List<Pregled>();
            Pregledi = new List<Pregled>();
            pregledController = (Application.Current as App).PregledController;
            tabelaPregleda = pregledController.DobaviSveSekretar();
            foreach (Pregled p in tabelaPregleda)
                Pregledi.Add(p);
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void DvoklikNaPregled(object sender, MouseButtonEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            IzmenaPregledaSWindow ip = new IzmenaPregledaSWindow(p);
            ip.Show();
            this.Close();
        }
        private void OtkaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled selektovaniPregled = (Pregled)dataGridPregledi.SelectedItems[0];
            MessageBoxResult retMessage = MessageBox.Show("Da li želite da otkažete pregled?", "PROVERA", MessageBoxButton.YesNo);
            if(retMessage==MessageBoxResult.Yes)
            {
                if (pregledController.OtkazivanjeSekretar(selektovaniPregled))
                {
                    List<Pregled> refreshTabelePregleda = pregledController.DobaviSveSekretar();
                    ProzorSaNotifikacijom();
                    dataGridPregledi.ItemsSource = refreshTabelePregleda;
                }
            }
        }
        private static void ProzorSaNotifikacijom()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno otkazan. " +
                "Poslato je obaveštenje pacijentu i doktoru da je pregled otkazan.";
            popup.Popup();
        }
    }
}

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
        public Boolean posalji = false;
        public List<Pregled> Pregledi { get; set; }
        public KalendarPregledaSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.GetListaPregledaSekretar();
            /*foreach (Pregled pobavestenje in Pregledi)
            {
                if (posalji == true)
                {
                    new ToastContentBuilder()
                   .AddArgument("action", "viewConversation")
                   .AddText("Vaš zakazani pregled je otkazan.")
                   .Show();
                }
            }*/
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            IzmenaPregledaSWindow ip = new IzmenaPregledaSWindow(p);
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
                        PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
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
                        posalji = true;
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.informacija;
                        popup.TitleText = "OBAVEŠTENJE";
                        popup.ContentText = "Pregled je uspešno otkazan. " +
                            "Poslato je obaveštenje pacijentu i doktoru da je pregled otkazan.";
                        popup.Popup();
                        this.Close();
                        break;
                    }
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

using Microsoft.Toolkit.Uwp.Notifications;
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
using Tulpep.NotificationWindow;

namespace ProjekatSIMS
{
    public partial class IzmenaPregledaSWindow : Window
    {
        public Boolean posalji = false;
        public PregledRepository fajl { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public Pregled pre { get; set; }
        public IzmenaPregledaSWindow(Pregled p)
        {
            InitializeComponent();
            this.DataContext = this;
            Pregledi = new List<Pregled>();
            Datum.SelectedDate = p.Pocetak;
            Sat.Text = p.Pocetak.Hour.ToString();
            Minut.Text = p.Pocetak.Minute.ToString();
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {

            double sati = Convert.ToDouble(Sat.Text);
            double minuti = Convert.ToDouble(Minut.Text);
            DateTime datum = (DateTime)Datum.SelectedDate;
            DateTime datumNovi = new DateTime();
            datumNovi = datum.AddHours(sati);
            datumNovi = datumNovi.AddMinutes(minuti);
            int slobodanTerminFlag = 0;

            //List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.GetListaPregledaSekretar();
            foreach (Pregled pregled in Pregledi)
            {
                if (pregled.Pocetak == datumNovi)
                {
                    MessageBox.Show("Ovaj termin je zauzet.", "OBAVEŠTENJE",MessageBoxButton.OK);
                    slobodanTerminFlag = 1;
                }

                if (slobodanTerminFlag == 0)
                {
                    Pregledi.Add(pre);
                    //string newJson = JsonConvert.SerializeObject(Pregledi);
                    //File.WriteAllText(@"..\..\..\Fajlovi\Pregled.txt", newJson);
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.informacija;
                    popup.TitleText = "OBAVEŠTENJE";
                    popup.ContentText = "Pregled je uspešno otkazan. " +
                       "Poslato je obaveštenje pacijentu i doktoru da je pregled otkazan.";
                    popup.Popup();
                    this.Close();
                }
            }
            fajl.SacuvajPregledSekretar(Pregledi);
        }
    }
}

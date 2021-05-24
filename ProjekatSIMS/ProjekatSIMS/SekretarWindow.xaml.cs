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
    public partial class SekretarWindow : Window
    {
        public SekretarWindow()
        {
            InitializeComponent();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Kreiranje_profila(object sender, RoutedEventArgs e)
        {
            KreirajProfilWindow kp = new KreirajProfilWindow();
            kp.Show();
        }
        private void Pretrazi_pacijente(object sender, RoutedEventArgs e)
        {
            PretraziPacijenteSWindow pp = new PretraziPacijenteSWindow();
            pp.Show();
        }
        private void Kalendar(object sender, RoutedEventArgs e)
        {
            KalendarPregledaSWindow kp = new KalendarPregledaSWindow();
            kp.Show();
        }

        private void Pretrazi_doktore(object sender, RoutedEventArgs e)
        {
            PretraziDoktoreSWindow pd = new PretraziDoktoreSWindow();
            pd.Show();
        }

        private void Naplata(object sender, RoutedEventArgs e)
        {

        }

        private void Zauzetost(object sender, RoutedEventArgs e)
        {

        }

        private void Oglasi(object sender, RoutedEventArgs e)
        {
            OglasnaTablaSWindow ot = new OglasnaTablaSWindow();
            ot.Show();
        }

        private void Hitna(object sender, RoutedEventArgs e)
        {
            OdabirPacijentaHitnoSWindow op = new OdabirPacijentaHitnoSWindow();
            op.Show();
        }

        private void Kreiranje_doktora(object sender, RoutedEventArgs e)
        {
            KreiranjeProfilaDoktoraSWindow kd = new KreiranjeProfilaDoktoraSWindow();
            kd.Show();
        }
    }
}

﻿using System;
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
            PretraziPacijenteSekretarWindow pp = new PretraziPacijenteSekretarWindow();
            pp.Show();
        }
        private void Kalendar(object sender, RoutedEventArgs e)
        {
            KalendarPregledaSWindow kp = new KalendarPregledaSWindow();
            kp.Show();
        }
        private void Zakazivanje(object sender, RoutedEventArgs e)
        {
            OdabirPrioritetaSWindow op = new OdabirPrioritetaSWindow();
            op.Show();
        }
        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            HitanNalogSWindow hn = new HitanNalogSWindow();
            hn.Show();
        }
    }
}

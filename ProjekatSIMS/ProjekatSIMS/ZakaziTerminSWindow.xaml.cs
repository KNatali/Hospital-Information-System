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
    public partial class ZakaziTerminSWindow : Window
    {
        public ZakaziTerminSWindow()
        {
            InitializeComponent();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            /*String jmbg_p = Jmbg_pacijent.Text;
            String jmbg_d = Jmbg_doktor.Text;
            DateTime datum = (DateTime)Datum.SelectedDate;
            double sat;
            double minut;
            if(Termin.Visibility == Visibility.Visible)
            {
                sat = Convert.ToDouble(Sat.Text.Split(":")[0];
                minut = Convert.ToDouble(Minut.Text(":")[1]);
            }*/











            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\SviPregledi.txt");
            List<Pregled> pregledi = fajl.GetListaPregledaSekretar();
            pregledi.Add(p);
            fajl.SacuvajPregledSekretar(pregledi);
            MessageBox.Show("Termin je uspešno zakazan. Poslato je obaveštenje pacijentu i doktoru.", "OBAVEŠTENJE", MessageBoxButton.OK);
            this.Close();
        }
    }
}

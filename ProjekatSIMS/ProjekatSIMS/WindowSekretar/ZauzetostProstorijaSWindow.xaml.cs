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
using LiveCharts;
using LiveCharts.Wpf;
using Model;

namespace ProjekatSIMS
{
    public partial class ZauzetostProstorijaSWindow : Window
    {
        public DateTime datumOd { get; set; }
        public DateTime datumDo {get;set;}
        public Func<ChartPoint,string> PointLabel { get; set; }
        public ZauzetostProstorijaSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
        }

        private void Stampaj(object sender, RoutedEventArgs e)
        {
            IzvestajZauzetihProstorijaSWindow izp = new IzvestajZauzetihProstorijaSWindow((DateTime)DatumOD.SelectedDate,(DateTime)DatumDO.SelectedDate);
            izp.Show();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

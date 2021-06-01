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

namespace ProjekatSIMS
{
    public partial class ZauzetostProstorijaSWindow : Window
    {
        public SeriesCollection seriesCollection { get; set; }
        public string[] Datumi { get; set; }
        public Func<double,string> Zauzetost { get; set; }
        public ZauzetostProstorijaSWindow()
        {
            InitializeComponent();
            DataContext = this;
            seriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="val1",
                    Values=new ChartValues<double> {5,10}
                }
            };
            seriesCollection.Add(new ColumnSeries
            {
                Title="val2",
                Values=new ChartValues<double> {10,15}
            });
            Datumi = new[] { "values 1", "values 2" };
            Zauzetost = value => value.ToString("N"); 
        }

        private void Stampaj(object sender, RoutedEventArgs e)
        {

        }

        private void Nazad(object sender, RoutedEventArgs e)
        {

        }
    }
}

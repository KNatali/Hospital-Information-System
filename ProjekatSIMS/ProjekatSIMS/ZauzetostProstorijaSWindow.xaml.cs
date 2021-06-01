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
using Separator = LiveCharts.Wpf.Separator;

namespace ProjekatSIMS
{
    public partial class ZauzetostProstorijaSWindow : Window
    {
        public List<Prostorija> prostorije { get; set; }
        public DateTime datumOd { get; set; }
        public DateTime datumDo {get;set;}
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
                    Values=new ChartValues<double> {0.1,0.4}
                }
            };
            seriesCollection.Add(new ColumnSeries
            {
                Title="val2",
                Values=new ChartValues<double> {1,2}
            });
            Datumi = new[] { "values 1", "values 2" };
            Zauzetost = value => value.ToString("N"); 
            /*Dijagram.Series.Add(new LineSeries
            {
                Values=new ChartValues<double> { 3,4,7,5,6,9 },
                StrokeThickness=4,
                StrokeDashArray=new System.Windows.Media.DoubleCollection(50),
                PointGeometry=null
            });
            Dijagram.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 6,2,4,1,3,5 },
                StrokeThickness = 2,
                PointGeometrySize = 20
            });
            Dijagram.AxisX.Add(new Axis
            {
                IsMerged=true,
                Separator=new Separator
                {
                    StrokeThickness=1,
                    StrokeDashArray=new DoubleCollection(2)
                }
            });
            Dijagram.AxisY.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new DoubleCollection(5)
                }
            });*/
        }

        private void Stampaj(object sender, RoutedEventArgs e)
        {

        }

        private void Nazad(object sender, RoutedEventArgs e)
        {

        }

        private void Prikazi(object sender, RoutedEventArgs e)
        {
            /*datumOd = (DateTime)DatumOD.SelectedDate;
            datumDo = (DateTime)DatumDO.SelectedDate;
            Dijagram.Visibility = Visibility.Visible;
            Dijagram.Series.Clear();
            seriesCollection = new SeriesCollection();

            seriesCollection.Add(new LineSeries());
            Dijagram.Series = seriesCollection;*/
        }
    }
}

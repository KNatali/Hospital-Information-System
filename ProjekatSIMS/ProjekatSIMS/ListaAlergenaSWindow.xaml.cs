using Model;
using Newtonsoft.Json;
using Repository;
using Controller;
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
using System.Collections.ObjectModel;

namespace ProjekatSIMS
{
    public partial class ListaAlergenaSWindow : Window
    {
        Point startPoint = new Point();
        private ZdravstvenikartonController zdravstveniKartonController;
        //public List<String> Alergeni { get; set; }
        public Pacijent pacijent { get; set; }
        public ObservableCollection<String> SviAlergeni
        {
            get;
            set;
        }

        public ObservableCollection<String> Alergeni
        {
            get;
            set;
        }
        public ListaAlergenaSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pacijent = p;
            List<String> a = new List<String>();
            a.Add("Polen");
            a.Add("Prašina");
            a.Add("Ambrozija");
            
            SviAlergeni = new ObservableCollection<String>(a);
            Alergeni = new ObservableCollection<String>();

            /*List<String> alergeni = new List<String>();
            Alergeni = new List<String>();
            zdravstveniKartonController = new ZdravstvenikartonController();
            alergeni = zdravstveniKartonController.DobaviSveAlergene(pacijent);
            dataGridAlergeni.ItemsSource = alergeni;*/
        }
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem == null) return;

                // Find the data behind the ListViewItem
                String alergen = (String)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", alergen);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                String alergen = e.Data.GetData("myFormat") as String;
                SviAlergeni.Remove(alergen);
                Alergeni.Add(alergen);
                ZdravstvenikartonController zdravstvenikartonController = new ZdravstvenikartonController();
                zdravstvenikartonController.kreiranjeAlergena(alergen, pacijent);
            }
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Novi_alergen(object sender, RoutedEventArgs e)
        {
            this.Close();
            NoviAlergenSWindow na = new NoviAlergenSWindow(pacijent);
            na.Show();
        }
    }
}

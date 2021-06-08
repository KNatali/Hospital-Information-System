using Model;
using ProjekatSIMS.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    
    public partial class IzvjestajLijekova : Page
    {
        public IzvjestajLijekova(IntervalDatuma interval, ObservableCollection<IzvjestajLijekDTO> izvjestaj)
        {
            InitializeComponent();
            DatumOd.Text = interval.PocetnoVrijeme.ToString();
            DatumDo.Text = interval.KrajnjeVrijeme.ToString();
            dataGridIzvjestaj.ItemsSource = izvjestaj;
        }

        private void Stampaj(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(Stampanje, "bilosta");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }

   
}

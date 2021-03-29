using ProjekatSIMS.Model.DoktorModel;
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
    /// <summary>
    /// Interaction logic for DoktorWindow.xaml
    /// </summary>
    public partial class DoktorWindow : Window
    {
        public DoktorWindow()
        {
            InitializeComponent();
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            ZakaziPregled z = new ZakaziPregled();
            z.Show();

        }

        private void PrikazPregleda(object sender, RoutedEventArgs e)
        {
            PrikazPregleda p = new PrikazPregleda();
            p.Show();

        }
    }
}

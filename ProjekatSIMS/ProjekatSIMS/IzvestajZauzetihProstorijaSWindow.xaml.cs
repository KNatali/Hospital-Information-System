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
    /// Interaction logic for IzvestajZauzetihProstorijaSWindow.xaml
    /// </summary>
    public partial class IzvestajZauzetihProstorijaSWindow : Window
    {
        public IzvestajZauzetihProstorijaSWindow()
        {
            InitializeComponent();
        }

        private void Stampanje(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Izveštaj se štampa u PDF formatu.","OBAVEŠTENJE");
            this.Close();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

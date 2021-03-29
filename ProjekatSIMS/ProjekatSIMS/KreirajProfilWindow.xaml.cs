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
    /// Interaction logic for KreirajProfilWindow.xaml
    /// </summary>
    public partial class KreirajProfilWindow : Window
    {
        public KreirajProfilWindow()
        {
            InitializeComponent();
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li ste sigurni?", "Provera", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    SekretarWindow s = new SekretarWindow();
                    s.Show();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

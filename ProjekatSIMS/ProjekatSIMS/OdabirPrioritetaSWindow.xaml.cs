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
    /// Interaction logic for OdabirPrioritetaSWindow.xaml
    /// </summary>
    public partial class OdabirPrioritetaSWindow : Window
    {
        public OdabirPrioritetaSWindow()
        {
            InitializeComponent();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            ZakaziTerminSWindow zt = new ZakaziTerminSWindow();
            zt.Show();
        }
    }
}

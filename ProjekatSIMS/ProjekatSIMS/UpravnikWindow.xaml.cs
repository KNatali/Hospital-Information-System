using ProjekatSIMS.Model.UpravnikModel;
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
   
    public partial class UpravnikWindow : Window
    {
        public UpravnikWindow()
        {
            InitializeComponent();
        }

        private void Upravljaj_Click(object sender, RoutedEventArgs e)
        {
           UpravljajWindow uw = new UpravljajWindow();
           uw.Show();
        }

        private void Pregledaj_Click(object sender, RoutedEventArgs e)
        {
            PregledajWindow pw = new PregledajWindow();
           pw.Show();
        }
    }
}

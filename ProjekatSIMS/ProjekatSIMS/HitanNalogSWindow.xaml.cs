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
    /// Interaction logic for HitanNalogSWindow.xaml
    /// </summary>
    public partial class HitanNalogSWindow : Window
    {
        public HitanNalogSWindow()
        {
            InitializeComponent();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kreirali ste hitan nalog pacijentu. Sada morate da zakažete termin.", "OBAVEŠTENJE", MessageBoxButton.OK);
            OdabirPrioritetaSWindow op = new OdabirPrioritetaSWindow();
            op.Show();
            this.Close();
        }
    }
}

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
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete kreiranje hitnog naloga?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Kreirali ste hitan nalog pacijentu. Da li želite da zakažete termin.", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    OdabirPrioritetaSWindow op = new OdabirPrioritetaSWindow();
                    op.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    this.Close();
                    break;
            }
            
        }
    }
}

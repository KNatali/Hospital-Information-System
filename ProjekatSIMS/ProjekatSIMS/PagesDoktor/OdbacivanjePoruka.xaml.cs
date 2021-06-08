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
    /// Interaction logic for OdbacivanjePoruka.xaml
    /// </summary>
    public partial class OdbacivanjePoruka : Window
    {
        public String Poruka { get; set; }
        public OdbacivanjePoruka()
        {
            InitializeComponent();
        }

        private void PotvrdiPoruku(object sender, RoutedEventArgs e)
        {
           
            this.Close();
            Poruka=UnijetaPoruka.Text;
        }
    }
}

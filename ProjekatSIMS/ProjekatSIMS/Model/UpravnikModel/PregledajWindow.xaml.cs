using Model.UpravnikModel;
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

namespace ProjekatSIMS.Model.UpravnikModel
{
    public partial class PregledajWindow : Window
    {
        public PregledajWindow()
        {
            InitializeComponent();
            List<Prostorija> prostorije = new List<Prostorija>();
            lvProstorije.ItemsSource = prostorije;

        }
    }
}

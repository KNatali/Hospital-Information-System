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
    /// <summary>
    /// Interaction logic for KreirajWindow.xaml
    /// </summary>
    public partial class KreirajWindow : Window
    {
        public KreirajWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        
        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            String id = Id.Text;
            int sprat = Convert.ToInt32(Sprat.Text);
            //EnumProstorija ep = new EnumProstorija();
            Prostorija p = new Prostorija();
            if (B1.IsChecked == true)
                p.vrsta = EnumProstorija.Sala;
            if (B2.IsChecked == true)
                p.vrsta = EnumProstorija.Soba;
            if (B3.IsChecked == true)
                p.vrsta = EnumProstorija.Kancelarija;
            if (B4.IsChecked == true)
                p.vrsta = EnumProstorija.Magacin;
            else
                p.vrsta = EnumProstorija.Ordiracija;



        }
        
    }
}

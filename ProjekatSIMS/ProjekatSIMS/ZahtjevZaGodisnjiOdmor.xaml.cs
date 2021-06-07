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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for ZahtjevZaGodisnjiOdmor.xaml
    /// </summary>
    public partial class ZahtjevZaGodisnjiOdmor : Page
    {
        public ZahtjevZaGodisnjiOdmor()
        {
            InitializeComponent();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();


        }
    }
}


using ProjekatSIMS.ViewModelDoktor;
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

namespace ProjekatSIMS.ViewDoktor
{
<<<<<<< HEAD:ProjekatSIMS/ProjekatSIMS/HelpUpravnik.xaml.cs
    /// <summary>
    /// Interaction logic for HelpUpravnik.xaml
    /// </summary>
    public partial class HelpUpravnik : Page
    {
        public HelpUpravnik()
=======
    
    public partial class PocetnaStranicaDoktorView : Page
    {
        public PocetnaStranicaDoktorView(PocetnaStranicaDoktorViewModel viewModel)
>>>>>>> main:ProjekatSIMS/ProjekatSIMS/ViewDoktor/PocetnaStranicaDoktorView.xaml.cs
        {

            InitializeComponent();
<<<<<<< HEAD:ProjekatSIMS/ProjekatSIMS/HelpUpravnik.xaml.cs
        }
=======
            this.DataContext = viewModel;
        }

       
>>>>>>> main:ProjekatSIMS/ProjekatSIMS/ViewDoktor/PocetnaStranicaDoktorView.xaml.cs
    }
}

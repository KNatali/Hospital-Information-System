using ProjekatSIMS.ViewModelSekretar;
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

namespace ProjekatSIMS.ViewSekretar
{
    public partial class PretragaPacijenataView : Window
    {
        public PretragaPacijenataView(PretragaPacijenataViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.ViewModelSekretar.PretragaPacijenataViewModel(this.navService);
        }
    }
}

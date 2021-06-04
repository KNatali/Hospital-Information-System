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
using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewModelDoktor;

namespace ProjekatSIMS.ViewDoktor
{

    public partial class TutorijalDoktor1View : Page
    {
        public TutorijalDoktor1View(TutorijalDoktor1ViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}

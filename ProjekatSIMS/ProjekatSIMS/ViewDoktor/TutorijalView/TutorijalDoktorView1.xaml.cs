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

    public partial class TutorijalDoktorView1 : Window
    {

        private TutorijalDoktorViewModel1 viewModel;
        private NavigationService NavigationService { get; set; }
        public TutorijalDoktorViewModel1 _ViewModel
        {
            get { return viewModel; }
            set
            {
                viewModel = value;
            }
        }
        public TutorijalDoktorView1()
        {
            InitializeComponent();
            this.viewModel = new TutorijalDoktorViewModel1(this.TutorijalFrame.NavigationService);
            this.DataContext = this.viewModel;
        }
    }
}

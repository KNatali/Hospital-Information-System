using Model;
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

namespace ProjekatSIMS.ViewPacijent
{
    /// <summary>
    /// Interaction logic for VidiPregledeView.xaml
    /// </summary>
    public partial class VidiPregledeView : Page
    {
        public Pacijent trenutniPacijent { get; set; }
        public VidiPregledeView(Pacijent pacijent)
        {
            InitializeComponent();
            trenutniPacijent = pacijent;
            this.DataContext = new ViewModelPacijent.VidiPregledeViewModel(trenutniPacijent);
        }
    }
}

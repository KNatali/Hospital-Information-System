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
using Model;

namespace ProjekatSIMS.ViewSekretar
{
    /// <summary>
    /// Interaction logic for ProfilPacijentaView.xaml
    /// </summary>
    public partial class ProfilPacijentaView : Window
    {
        private Pacijent pacijent;
        public ProfilPacijentaView(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = new ViewModelSekretar.ProfilPacijentaViewModel(pacijent, this);
        }
    }
}

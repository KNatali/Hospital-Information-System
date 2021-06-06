using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS.ViewSekretar
{
    public partial class ProfilDoktoraView : Window
    {
        private Doktor doktor;
        public ProfilDoktoraView(Doktor doktor)
        {
            InitializeComponent();
            this.DataContext = new ViewModelSekretar.ProfilDoktoraViewModel(doktor, this);
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
            Oblasti.SelectedItem = doktor.Specijalizacija;
        }

    }
}

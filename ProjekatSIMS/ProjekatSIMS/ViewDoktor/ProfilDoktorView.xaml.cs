﻿using ProjekatSIMS.ViewModelDoktor;
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
  
    public partial class ProfilDoktorView : Page
    {
        public ProfilDoktorView(ProfilDoktorViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

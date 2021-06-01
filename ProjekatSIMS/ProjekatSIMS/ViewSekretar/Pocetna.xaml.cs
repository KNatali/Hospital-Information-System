﻿using System;
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
using ProjekatSIMS.ViewModelSekretar;

namespace ProjekatSIMS.ViewSekretar
{
    public partial class Pocetna : Window
    {
        private Pocetna viewModel;
        public Pocetna()
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.ViewModelSekretar.Pocetna();
        }
        public Pocetna _ViewModel
        {
            get { return viewModel; }
            set
            {
                viewModel = value;
            }
        }
    }
}

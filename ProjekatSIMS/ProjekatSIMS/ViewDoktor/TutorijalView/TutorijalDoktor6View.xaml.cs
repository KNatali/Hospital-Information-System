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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjekatSIMS.ViewModelDoktor.TutorijalViewModel;

namespace ProjekatSIMS.ViewDoktor.TutorijalView
{
    public partial class TutorijalDoktor6View : Page
    {
        public TutorijalDoktor6View(TutorijalDoktor6ViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
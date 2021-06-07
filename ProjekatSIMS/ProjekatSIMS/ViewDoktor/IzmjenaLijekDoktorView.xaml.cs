using Controller;
using Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.ViewModelDoktor;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.ViewDoktor
{

    public partial class IzmjenaLijekDoktorView : Page
    {
       
        
        public IzmjenaLijekDoktorView(IzmjenaLijekDoktorViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
           
        }



        private void Odustani(object sender, RoutedEventArgs e)
        {

            this.NavigationService.GoBack();

        }
    }
}

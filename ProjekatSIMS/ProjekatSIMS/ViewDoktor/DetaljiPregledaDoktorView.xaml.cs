using Controller;
using Model;
using System;
using System.Windows;
using ProjekatSIMS.ViewModelDoktor;

namespace ProjekatSIMS.ViewDoktor
{

    public partial class DetaljiPregledaDoktorView : Window
    {
      

        
        public DetaljiPregledaDoktorView(DetaljiPregledaDoktorViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
           

        }

      
    
    }
}

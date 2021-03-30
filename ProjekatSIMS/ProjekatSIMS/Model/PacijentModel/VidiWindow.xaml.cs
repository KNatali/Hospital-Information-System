using Model;
using Model.DoktorModel;
using Model.PacijentModel;
using Model.UpravnikModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS.Model.PacijentModel
{
    
    public partial class VidiWindow : Window
    {
       public List<Pregled> Pregledi 
        { 
            get; 
            set;
        }
        public VidiWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Pregled.txt");
            Pregledi = fajl.DobaviSve();
            
            
        }

    }
}

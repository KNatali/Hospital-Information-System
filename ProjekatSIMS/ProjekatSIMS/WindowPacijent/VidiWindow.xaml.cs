using Model;
using Repository;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS
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
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();
        }
    }
}

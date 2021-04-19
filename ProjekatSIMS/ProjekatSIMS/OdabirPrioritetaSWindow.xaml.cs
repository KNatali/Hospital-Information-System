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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    public partial class OdabirPrioritetaSWindow : Window
    {
        public OdabirPrioritetaSWindow()
        {
            InitializeComponent();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            string str = Tip.Text;
            ComboBoxItem cbi = (ComboBoxItem)Tip.SelectedItem;
            string opcija = cbi.Content.ToString();
            string val = Tip.SelectedValue.ToString();
            if(opcija == "-")
            {
                ZakaziTerminSWindow zt = new ZakaziTerminSWindow();
                zt.Show();
            }
            else if(opcija == "Kod određenog doktora")
            {
                PrioritetDoktorSWindow pd = new PrioritetDoktorSWindow();
                pd.Show();
            }
            else if(opcija == "U određeno vreme")
            {
                PrioritetDatumSWindow pda = new PrioritetDatumSWindow();
                pda.Show();
            }
        }
    }
}

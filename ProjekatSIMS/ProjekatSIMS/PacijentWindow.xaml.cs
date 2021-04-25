 using Microsoft.Toolkit.Uwp.Notifications;
using Model;
using ProjekatSIMS.WindowPacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS
{

    public partial class PacijentWindow : Window
    {
        public List<Recept> Recepti
        {
            get;
            set;
        }
        
        public PacijentWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Recepti = new List<Recept>();
            ReceptRepository fajl = new ReceptRepository(@"..\..\..\Fajlovi\Recept.txt");
            Recepti = fajl.DobaviSveRecepte();

            foreach (Recept r in Recepti)
            {
                int res = DateTime.Compare(r.DatumPropisivanjaLeka.AddHours(-4), DateTime.UtcNow);
                
                if(res>0)
                {
                    if((r.DatumPropisivanjaLeka.Month == DateTime.UtcNow.Month) && (r.DatumPropisivanjaLeka.Day == DateTime.UtcNow.Day) && (r.DatumPropisivanjaLeka.Year == DateTime.UtcNow.Year))
                   
                    {
                    new ToastContentBuilder()
                   .AddArgument("action", "viewConversation")
                   .AddText("Danas treba da uzmete svoju terapiju")
                   .AddText(r.NazivLeka + " " + r.Kolicina + " " + r.Uputstvo + ", uzeti u " + r.DatumPropisivanjaLeka.TimeOfDay.ToString())
                   .Show( toast =>
                   {
                       toast.ExpirationTime = DateTime.UtcNow.AddDays(2);
                   }
                         
                        );

                    }
                }

            }




        }

        private void Click_zakazi(object sender, RoutedEventArgs e)
        {
            ZakaziWindow zw = new ZakaziWindow();
            zw.Show();
        }

        private void Click_otkazi(object sender, RoutedEventArgs e)
        {
            OtkaziWindow ow = new OtkaziWindow();
            ow.Show();
        }

        private void Click_izmeni(object sender, RoutedEventArgs e)
        {
            IzmeniWindow iw = new IzmeniWindow();
            iw.Show();
        }

        private void Click_vidi(object sender, RoutedEventArgs e)
        {
            VidiWindow vw = new VidiWindow();
            vw.Show();
        }

        
    }
}

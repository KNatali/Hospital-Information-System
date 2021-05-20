 using Microsoft.Toolkit.Uwp.Notifications;
using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
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
        public List<Pregled> pregledi
        {
            get;
            set;
        }
        public List<Podsetnik> Podsetnici
        {
            get;
            set;
        }

        public int mozeSeOceniti = 0;
        
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

        private void OceniBolnicu_Click(object sender, RoutedEventArgs e)
        {
            OceniBolnicuWindow obw = new OceniBolnicuWindow();
            if(mozeSeOceniti == 1)
            {
                obw.Show();
            }
            else
            {
                MessageBox.Show("Bolnicu mozete oceniti tek kada imate makar jedan zavrsen pregled.");
            }
            
        }

        private void VidiOceneBolnice_Click(object sender, RoutedEventArgs e)
        {
            VidiOceneBolniceWindow vobw = new VidiOceneBolniceWindow();
            vobw.Show();
        }

        private void OceniLekara_Click(object sender, RoutedEventArgs e)
        {
            OceniLekaraWindow olw = new OceniLekaraWindow();
            olw.Show();
        }

        private void VidiOceneLekara_Click(object sender, RoutedEventArgs e)
        {
            VidiOceneLekaraWindow volw = new VidiOceneLekaraWindow();
            volw.Show();
        }

        private void Podsetnik_Click(object sender, RoutedEventArgs e)
        {
            KreirajPodsetnikWindow kpw = new KreirajPodsetnikWindow();
            kpw.Show();
        }
    }
}

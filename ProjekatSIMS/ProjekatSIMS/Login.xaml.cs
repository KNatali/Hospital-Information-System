using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.UpravnikWindows;
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
    public partial class Login : Window
    {
        public List<RegistrovaniKorisnik> RegistrovaniKorisnici
        {
            get;
            set;
        }
        public Login()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        private void PrijaviSe(object sender, RoutedEventArgs e)
        {
            String korisnickoIme = KorisnickoIme.Text;
            String lozinka = Lozinka.Text;
            Uloga uloga = Uloga.Pacijent;
            LoginRepository loginRepository = new LoginRepository();
            RegistrovaniKorisnici = loginRepository.DobaviSveRegistrovaneKorisnike();

            foreach (RegistrovaniKorisnik rk in RegistrovaniKorisnici)
            {
                if((rk.KorisnickoIme == korisnickoIme) && (rk.Lozinka == lozinka))
                {
                    uloga = rk.uloga;
                }
            }
            switch (uloga)
            {
                case Uloga.Pacijent:
                    WindowPacijent.PacijentMainWindow pacijentMainWindow = new WindowPacijent.PacijentMainWindow();
                    pacijentMainWindow.Show();
                    break;
                case Uloga.Sekretar:
                    SekretarWindow sekretarWindow = new SekretarWindow();
                    sekretarWindow.Show();
                    break;
                case Uloga.Upravnik:
                    Upravnik uw = new Upravnik();
                    uw.Show();
                    break;
                


            }



        }
    }
}

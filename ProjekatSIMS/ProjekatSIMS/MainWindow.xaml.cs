
using Model;
using ProjekatSIMS.Controller;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;

using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS
{
    public partial class MainWindow : Window
    {
        public List<RegistrovaniKorisnik> RegistrovaniKorisnici
        {
            get;
            set;
        }
        public LoginController loginController = new LoginController();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void PrijaviSe(object sender, RoutedEventArgs e)
        {
            String korisnickoIme = KorisnickoIme.Text;
            String lozinka = Lozinka.Text;
            Uloga uloga = Uloga.Doktor;
            LoginRepository loginRepository = new LoginRepository();
            RegistrovaniKorisnici = loginRepository.DobaviSveRegistrovaneKorisnike();


            foreach (RegistrovaniKorisnik rk in RegistrovaniKorisnici)
            {
                if ((rk.KorisnickoIme == korisnickoIme) && (rk.Lozinka == lozinka))
                {
                    uloga = rk.uloga;
                }
            }

            if ((loginController.DaLiJeKorisnikBlokiran(korisnickoIme) == true) && (uloga == Uloga.Pacijent))
            {
                MessageBox.Show("Blokirani ste.");
            }
            else
            {
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
                       
                        UpravnikWindow upravnikWindow = new UpravnikWindow();
                        upravnikWindow.Show();
                        break;
                    case Uloga.Doktor:
                        DoktorWindowView doktorWindow = new DoktorWindowView();
                        doktorWindow.Show();
                        break;

                }
            }

            



        }
    }
}


using Model;
using ProjekatSIMS.Controller;
using ProjekatSIMS.Model;
using ProjekatSIMS.UpravnikWindows;
using ProjekatSIMS.ViewDoktor;
using Repository;
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
        public List<Pacijent> Pacijenti
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
            String lozinka = Lozinka.Password;
            Uloga uloga = Uloga.Doktor;
            LoginRepository loginRepository = new LoginRepository();
            RegistrovaniKorisnici = loginRepository.DobaviSveRegistrovaneKorisnike();
            PacijentRepository pacijentRepository = new PacijentRepository();
            Pacijenti = pacijentRepository.DobaviSve();
            Pacijent pacijent = new Pacijent();


            foreach (RegistrovaniKorisnik rk in RegistrovaniKorisnici)
            {
                if ((rk.KorisnickoIme == korisnickoIme) && (rk.Lozinka == lozinka))
                {
                    uloga = rk.uloga;
                }
            }
            foreach (Pacijent p in Pacijenti)
            {
                if (p.Jmbg == korisnickoIme)
                {
                    pacijent = p;
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
                        WindowPacijent.PacijentMainWindow pacijentMainWindow = new WindowPacijent.PacijentMainWindow(pacijent);
                        pacijentMainWindow.Show();
                        break;
                    case Uloga.Sekretar:
                        Pocetna pocetna = new Pocetna();
                        pocetna.Show();
                        //SekretarWindow sekretarWindow = new SekretarWindow();
                        //sekretarWindow.Show();
                        break;
                    case Uloga.Upravnik:
                        Upravnik upravnikWindow = new Upravnik();
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

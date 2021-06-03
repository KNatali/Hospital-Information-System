using Model;
using ProjekatSIMS.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS.UpravnikWindows
{
    
    public partial class Profil : Page
    {
        public RegistrovaniKorisnik registrovaniKorisnik { get; set; }
        public List<RegistrovaniKorisnik> registrovaniKorisnici { get; set; }
        public LoginRepository LoginRepository { get; set; }
        public Profil(RegistrovaniKorisnik korisnik)
        {
            InitializeComponent();
            this.DataContext = this;
            registrovaniKorisnik = korisnik;
            registrovaniKorisnici = new List<RegistrovaniKorisnik>();
            LoginRepository = new LoginRepository();
            registrovaniKorisnici = LoginRepository.DobaviSveRegistrovaneKorisnike();

        }
        private void IzmeniLozinku(object sender, RoutedEventArgs e)
        {
            if(NovaLozinka1.Password.ToString() != NovaLozinka2.Password.ToString())
            {
                MessageBox.Show("Niste uneli u polja 2 puta istu lozinku, pokusajte opet!");
                StaraLozinka.Password = "";
                NovaLozinka1.Password = "";
                NovaLozinka2.Password = "";
            }
            foreach(RegistrovaniKorisnik rk in registrovaniKorisnici)
            {
                if((rk.KorisnickoIme == registrovaniKorisnik.KorisnickoIme) )
                {
                    rk.Lozinka = NovaLozinka1.Password.ToString();
                    MessageBox.Show("Uspesno ste promenili lozinku! Neophodno je da se opet registrujete!");
                    
                    Upravnik uw = (Upravnik)Window.GetWindow(this);
                    uw.Close();
                    //zavrsiti da se sifra sacuva u fajl doraditi repository
                    MainWindow mw = new MainWindow();
                }
               
            }

        }

    }
}

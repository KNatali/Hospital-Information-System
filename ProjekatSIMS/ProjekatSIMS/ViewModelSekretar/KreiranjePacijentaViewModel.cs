using Controller;
using Model;
using ProjekatSIMS.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class KreiranjePacijentaViewModel : BindableBase
    {
        private NavigationService navService;
        private RelayCommand otkazi;
        private RelayCommand kreiraj;
        private String jmbg;
        private String ime;
        private String prezime;
        private DateTime datum;
        private String telefon;
        private String mail;
        private String adresa;
        private Window thisWindow;
        private PacijentController pacijentController = new PacijentController();
        public RelayCommand<string> NavCommand { get; private set; }
        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }
        public RelayCommand Otkazi_kreiranje
        {
            get { return otkazi; }
            set
            {
                otkazi = value;
            }
        }
        public RelayCommand Kreiraj_profil
        {
            get { return kreiraj; }
            set
            {
                kreiraj = value;
            }
        }
        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                if (jmbg != value)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                if (ime != value)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (prezime != value)
                {
                    prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                if (datum != value)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        public string Telefon
        {
            get { return telefon; }
            set
            {
                if (telefon != value)
                {
                    telefon = value;
                    OnPropertyChanged("Telefon");
                }
            }
        }
        public string Mail
        {
            get { return mail; }
            set
            {
                if (mail != value)
                {
                    mail = value;
                    OnPropertyChanged("Mail");
                }
            }
        }
        public string Adresa
        {
            get { return adresa; }
            set
            {
                if (adresa != value)
                {
                    adresa = value;
                    OnPropertyChanged("Adresa");
                }
            }
        }
        private string _imeError;
        public string ImeError
        {
            get { return _imeError; }
            set
            {
                _imeError = value;
                OnPropertyChanged("ImeError");
            }
        }
        private string _jmbgError;
        public string JmbgError
        {
            get { return _jmbgError; }
            set 
            {
                _jmbgError = value;
                OnPropertyChanged("JmbgError");
            }
        }
        public KreiranjePacijentaViewModel()
        {

        }
        public KreiranjePacijentaViewModel(Window thisWindow)
        {
            this.thisWindow = thisWindow;
            Kreiraj_profil = new RelayCommand(Executed_Kreiraj);
            Otkazi_kreiranje = new RelayCommand(Executed_Odustani);
        }
        public void Executed_Kreiraj()
        {
            BrisiTextBlokove();
            if (Validacije() == false) return;
            Pacijent p = new Pacijent();
            p.Jmbg = Jmbg;
            p.Ime = Ime;
            p.Prezime = Prezime;
            p.DatumRodjenja = Datum;
            p.BrojTelefona = Telefon;
            p.Email = Mail;
            p.Adresa = Adresa;
            pacijentController.KreiranjeProfila(p);
            MessageBoxResult ret = MessageBox.Show("Profil pacijenta je uspešno kreiran. Da li želite da pregledate njegov profil", "OBAVEŠTENJE", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                Window window = new ViewSekretar.ProfilPacijentaView(p);
                window.Show();
                thisWindow.Close();
            }
            //else
                //this.NavService.GoBack();
        }

        private void BrisiTextBlokove()
        {
            this.ImeError = "";
        }

        private bool Validacije()
        {
            if (ImeValidacija() == false) return false;
            if (JmbgValidacija() == false) return false;
            return true;
        }

        private bool JmbgValidacija()
        {
            if (PrazanJmbg() == false) return false;
            if (CifreJmbg() == false) return false;
            return true;
        }

        private bool CifreJmbg()
        {
            if(Jmbg.Length != 13)
            {
                this.JmbgError = "Greska u broju cifara";
                return false;
            }
            return true;
        }

        private bool PrazanJmbg()
        {
            if(Jmbg == null)
            {
                this.JmbgError = "Greska jmbg";
                return false;
            }
            return true;
        }

        private bool ImeValidacija()
        {
            if (Ime == null)
            {
                this.ImeError = "Greska u imenun";
                return false;
            }
            return true;
        }

        public void Executed_Odustani()
        {
            thisWindow.Close();
        }
        public KreiranjePacijentaViewModel(NavigationService service)
        {
            this.navService = service;
            this.Kreiraj_profil = new RelayCommand(Executed_Kreiraj);
            this.Otkazi_kreiranje = new RelayCommand(Executed_Odustani);
        }
    }
}

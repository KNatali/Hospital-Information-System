using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using Model;
using ProjekatSIMS.Commands;
using Controller;
using ProjekatSIMS.Model;
using ProjekatSIMS.Controller;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class KreiranjeProfila : BindableBase
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
        private Uloga uloga;
        private Window thisWindow;
        private string imeError;
        private string prezimeError;
        private string jmbgError;
        private string datumError;
        private string telefonError;
        private string mailError;
        private string adresaError;
        private Controller.KreiranjeProfila kreiranjeProfila = new Controller.KreiranjeProfila();
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
        public Uloga Uloga
        {
            get { return uloga; }
            set
            {
                if (uloga != value)
                {
                    uloga = value;
                    OnPropertyChanged("Uloga");
                }
            }
        }
        public string ImeError
        {
            get { return imeError; }
            set
            {
                imeError = value;
                OnPropertyChanged("ImeError");
            }
        }
        public string PrezimeError
        {
            get { return prezimeError; }
            set
            {
                prezimeError = value;
                OnPropertyChanged("PrezimeError");
            }
        }
        public string JmbgError
        {
            get { return jmbgError; }
            set
            {
                jmbgError = value;
                OnPropertyChanged("JmbgError");
            }
        }
        public string DatumError
        {
            get { return datumError; }
            set
            {
                datumError = value;
                OnPropertyChanged("DatumError");
            }
        }
        public string TelefonError
        {
            get { return telefonError; }
            set
            {
                telefonError = value;
                OnPropertyChanged("TelefonError");
            }
        }
        public string MailError
        {
            get { return mailError; }
            set
            {
                mailError = value;
                OnPropertyChanged("MailError");
            }
        }
        public string AdresaError
        {
            get { return adresaError; }
            set
            {
                adresaError = value;
                OnPropertyChanged("AdresaError");
            }
        }
        public KreiranjeProfila()
        {

        }
        public KreiranjeProfila(Window thisWindow)
        {
            this.thisWindow = thisWindow;
            Kreiraj_profil = new RelayCommand(Executed_Kreiraj);
            Otkazi_kreiranje = new RelayCommand(Executed_Odustani);
        }
        public void Executed_Kreiraj()
        {
            BrisiTextBlokove();
            if (Validacije() == false) return;
            Osoba o = new Osoba();
            if (Uloga.Doktor == Uloga)
            {
                o.Jmbg = Jmbg;
                o.Ime = Ime;
                o.Prezime = Prezime;
                o.DatumRodjenja = Datum;
                o.BrojTelefona = Telefon;
                o.Email = Mail;
                o.Adresa = Adresa;
                kreiranjeProfila.KreirajProfil(Uloga, o);
                MessageBoxResult ret = MessageBox.Show("Profil doktora je uspešno kreiran.", "OBAVEŠTENJE");
            }
            else if (Uloga.Pacijent == Uloga)
            {
                o.Jmbg = Jmbg;
                o.Ime = Ime;
                o.Prezime = Prezime;
                o.DatumRodjenja = Datum;
                o.BrojTelefona = Telefon;
                o.Email = Mail;
                o.Adresa = Adresa;
                kreiranjeProfila.KreirajProfil(Uloga, o);
                MessageBoxResult ret = MessageBox.Show("Profil pacijenta je uspešno kreiran.", "OBAVEŠTENJE");
            }
            else
                MessageBox.Show("Možete kreirati samo pacijenta i doktora");
            thisWindow.Close();
        }

        private void BrisiTextBlokove()
        {
            this.ImeError = "";
            this.PrezimeError = "";
            this.JmbgError = "";
            this.DatumError = "";
            this.TelefonError = "";
            this.MailError = "";
            this.AdresaError = "";
        }

        private bool Validacije()
        {
            if (ImeValidacija() == false) return false;
            if (PrezimeValidacija() == false) return false;
            if (JmbgValidacija() == false) return false;
            if (DatumValidacija() == false) return false;
            if (TelefonValidacija() == false) return false;
            if (AdresaValidacija() == false) return false;
            if (MailValidacija() == false) return false;
            return true;
        }
        private bool ImeValidacija()
        {
            if (Ime == null)
            {
                this.ImeError = "Morate da unesete ime doktora.";
                return false;
            }
            return true;
        }
        private bool PrezimeValidacija()
        {
            if (Prezime == null)
            {
                this.PrezimeError = "Morate da unesete prezime doktora.";
                return false;
            }
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
            if (Jmbg.Length != 13)
            {
                this.JmbgError = "Jmbg mora da ima 13 cifara.";
                return false;
            }
            return true;
        }
        private bool PrazanJmbg()
        {
            if (Jmbg == null)
            {
                this.JmbgError = "Morate da unesete jmbg doktora.";
                return false;
            }
            return true;
        }
        private bool DatumValidacija()
        {
            if (Datum == null)
            {
                this.PrezimeError = "Morate da odaberete datum rođenja doktora.";
                return false;
            }
            return true;
        }
        private bool TelefonValidacija()
        {
            if (Telefon == null)
            {
                this.TelefonError = "Morate da unesete broj telefona doktora.";
                return false;
            }
            return true;
        }
        private bool AdresaValidacija()
        {
            if (Adresa == null)
            {
                this.AdresaError = "Morate da unesete adresu doktora.";
                return false;
            }
            return true;
        }
        private bool MailValidacija()
        {
            if (Mail == null)
            {
                this.MailError = "Morate da unesete email adresu doktora.";
                return false;
            }
            return true;
        }
        public void Executed_Odustani()
        {
            thisWindow.Close();
        }
        public KreiranjeProfila(NavigationService service)
        {
            this.navService = service;
            this.Kreiraj_profil = new RelayCommand(Executed_Kreiraj);
            this.Otkazi_kreiranje = new RelayCommand(Executed_Odustani);
        }
    }
}

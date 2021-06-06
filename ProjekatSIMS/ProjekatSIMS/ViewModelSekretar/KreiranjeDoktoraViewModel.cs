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
    public class KreiranjeDoktoraViewModel :BindableBase
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
        private String oblasti;
        private String radiOd;
        private String radiDo;
        private Window thisWindow;
        private string imeError;
        private string prezimeError;
        private string jmbgError;
        private string datumError;
        private string telefonError;
        private string mailError;
        private string adresaError;
        private string radnoVremeError;
        private DoktorController doktorController = new DoktorController();
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
        public String Oblasti
        {
            get { return oblasti; }
            set
            {
                if (oblasti != value)
                {
                    oblasti = value;
                    OnPropertyChanged("Oblasti");
                }
            }
        }
        public string RadiOd
        {
            get { return radiOd; }
            set
            {
                if (radiOd != value)
                {
                    radiOd = value;
                    OnPropertyChanged("RadiOd");
                }
            }
        }
        public string RadiDo
        {
            get { return radiDo; }
            set
            {
                if (radiDo != value)
                {
                    radiDo = value;
                    OnPropertyChanged("RadiDo");
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
        public string RadnoVremeError
        {
            get { return radnoVremeError; }
            set
            {
                radnoVremeError = value;
                OnPropertyChanged("RadnoVremeError");
            }
        }
        public KreiranjeDoktoraViewModel()
        {

        }
        public KreiranjeDoktoraViewModel(Window thisWindow)
        {
            this.thisWindow = thisWindow;
            Kreiraj_profil = new RelayCommand(Executed_Kreiraj);
            Otkazi_kreiranje = new RelayCommand(Executed_Odustani);
        }
        public void Executed_Kreiraj()
        {
            BrisiTextBlokove();
            if (Validacije() == false) return;
            Doktor d = new Doktor();
            d.Jmbg = Jmbg;
            d.Ime = Ime;
            d.Prezime = Prezime;
            d.DatumRodjenja = Datum;
            d.BrojTelefona = Telefon;
            d.Email = Mail;
            d.Adresa = Adresa;
            //d.Specijalizacija = (Specijalizacija)Oblasti;
            d.PocetakRadnogVremena = RadiOd;
            d.KrajRadnogVremena = RadiDo;
            doktorController.KreiranjeProfila(d);
            MessageBoxResult ret = MessageBox.Show("Profil doktora je uspešno kreiran. Da li želite da pregledate njegov profil", "OBAVEŠTENJE", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                Window window = new ViewSekretar.ProfilDoktoraView(d);
                window.Show();
                thisWindow.Close();
            }
            else
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
            this.RadnoVremeError = "";
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
            if (RadnoVremeValidacija() == false) return false;
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
        private bool RadnoVremeValidacija()
        {
            if (RadiOd == null || RadiDo == null)
            {
                this.RadnoVremeError = "Morate da unesete početak i kraj radnog vremena doktora.";
                return false;
            }
            return true;
        }
        public void Executed_Odustani()
        {
            thisWindow.Close();
        }
        public KreiranjeDoktoraViewModel(NavigationService service)
        {
            this.navService = service;
            this.Kreiraj_profil = new RelayCommand(Executed_Kreiraj);
            this.Otkazi_kreiranje = new RelayCommand(Executed_Odustani);
        }
    }
}

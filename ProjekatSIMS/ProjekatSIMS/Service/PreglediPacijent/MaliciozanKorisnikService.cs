using Model;
using ProjekatSIMS.Service.PretragaPacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.PreglediPacijent
{
   public  class MaliciozanKorisnikService
    {
        public int MAKSIMALNO_OTKAZIVANJA = 10;
        public Pacijent pacijent = new Pacijent();
        public TrazenjePacijentaService trazenjePacijenta = new TrazenjePacijentaService();
        public static PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        public List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();
        public Boolean DaLiJeKorisnikMaliciozan(String jmbg,Pacijent pac)
        {
            ProveraPodatakaPacijenta(jmbg);
            Pacijent pacijent = new Pacijent();
            if(trazenjePacijenta.DaLiPostojiPacijent(pac) == true)
            {
                return trazenjePacijenta.PronalazenjePacijenta(pac).jesteMaliciozanKorisnik;
            }
            return false;
        }

        public void ProveraPodatakaPacijenta(String jmbg)
        {
            foreach (Pacijent pacijent in DobavljanjePacijenataIzFajla())
            {
                if ((pacijent.Jmbg == jmbg) && (pacijent.otkazaoPregled >= MAKSIMALNO_OTKAZIVANJA))
                {
                    SlanjePorukeOBlokiranjuKorisnika(jmbg);
                    break;
                }
            }
        }

        public bool SlanjePorukeOBlokiranjuKorisnika(String jmbg)
        {
            
            foreach (Pacijent p in Pacijenti)
            {
                if ((p.Jmbg == jmbg))
                {
                    p.jesteMaliciozanKorisnik = true;
                }
            }
            pacijentRepository.Sacuvaj(Pacijenti);
            return true;
        }

        public List<Pacijent> DobavljanjePacijenataIzFajla()
        {
            List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();
            return Pacijenti;
        }
    }
}

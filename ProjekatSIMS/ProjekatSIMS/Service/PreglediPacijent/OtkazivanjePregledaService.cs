using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class OtkazivanjePregledaService
    {
        public static PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        public List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();
        public PregledRepository pregledRepository = new PregledRepository();
        public void ProveraVremenaZakazivanja(DateTime sadasnjeVreme)
        {
            foreach (Pacijent pacijent in Pacijenti)
            {
                int prosloNedeljuDana = DateTime.Compare(pacijent.datumPrvogZakazivanjaPregleda.AddDays(7), sadasnjeVreme);
                if (prosloNedeljuDana < 0)
                {
                    ObrisiPokusajeZakazivanja(pacijent.Ime, pacijent.Prezime);
                }
            }

        }
        public void ObrisiPokusajeZakazivanja(String ime, String prezime)
        {
            foreach (Pacijent pacijent in Pacijenti)
            {
                if ((pacijent.Prezime == prezime) && (pacijent.Ime == ime))
                {
                    pacijent.otkazaoPregled = 0;
                }
            }
        }

        public void BrojacOtkazivanjaPregleda(String ime, String prezime)
        {
            foreach (Pacijent pacijent in Pacijenti)
            {
                if ((pacijent.Prezime == prezime) && (pacijent.Ime == ime))
                {
                    pacijent.otkazaoPregled++;
                }
            }
        }

        public void OtkazivanjeZakazanihPregleda(Pacijent pac)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled pregled in pregledi)
            {
                if ((pregled.pacijent.Jmbg == pac.Jmbg))
                {
                    pregled.StatusPregleda = StatusPregleda.Otkazan;
                }
            }
        }
    }
}

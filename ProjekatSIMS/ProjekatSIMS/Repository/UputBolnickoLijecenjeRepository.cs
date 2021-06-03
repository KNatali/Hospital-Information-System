using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class UputBolnickoLijecenjeRepository
    {

        private String lokacijaFajla = @"..\..\..\Fajlovi\UputBolnickoLijecenje.txt";
        public List<UputBolnickoLijecenje> DobaviSveUpute()
        {
            List<UputBolnickoLijecenje> uputi = new List<UputBolnickoLijecenje>();
            using (StreamReader r = new StreamReader(lokacijaFajla))
            {
                string json = r.ReadToEnd();
                uputi = JsonConvert.DeserializeObject<List<UputBolnickoLijecenje>>(json);
            }
            return uputi;
        }

        public void SacuvajUpute(List<UputBolnickoLijecenje> uputi)
        {
            string newJson = JsonConvert.SerializeObject(uputi);
            File.WriteAllText(lokacijaFajla, newJson);
        }

        public void SacuvajUput(UputBolnickoLijecenje uput)
        {
            List<UputBolnickoLijecenje> sviUputi = DobaviSveUpute();
            if (sviUputi == null)
                sviUputi = new List<UputBolnickoLijecenje>();
            sviUputi.Add(uput);
            SacuvajUpute(sviUputi);
        }

        public List<UputBolnickoLijecenje> DobaviUputZaKarton(int id)
        {
            List<UputBolnickoLijecenje> sviUputi = DobaviSveUpute();
            List<UputBolnickoLijecenje> uputi = new List<UputBolnickoLijecenje>();
            foreach(UputBolnickoLijecenje u in sviUputi)
            {
                if (u.IdKartona == id)
                    uputi.Add(u);
            }

            return uputi;
        }
    }
}

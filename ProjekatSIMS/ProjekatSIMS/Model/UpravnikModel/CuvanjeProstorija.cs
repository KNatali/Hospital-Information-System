

using System;
using System.IO;
using System.Collections.Generic;
using Model.PacijentModel;
using Model.UpravnikModel;

namespace Model.UpravnikModel
{
    public class CuvanjeProstorija
    {
        private String lokacijaFajla;
        private List<Prostorija> prostorije;

        public CuvanjeProstorija(String lokacija)
        {
            lokacijaFajla = lokacija;
        }

        public void Sacuvaj(String prostorija, Boolean znak)
        {
            using StreamWriter file = new StreamWriter(lokacijaFajla, znak);

            file.WriteLineAsync(prostorija);

        }

        public List<Prostorija> UcitajProstorije()
        {
            prostorije = new List<Prostorija>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\mzari\Desktop\Projekat\Projekat\ProjekatSIMS\Prostorije.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");
                    Prostorija prostorija = new Prostorija();
                    prostorija.id = parts[0];
                    prostorija.sprat = Convert.ToInt32(parts[1]);
                    if (parts[2] == "Soba")
                        prostorija.vrsta = ProjekatSIMS.Model.UpravnikModel.EnumProstorija.Soba;
                    if (parts[2] == "Sala")
                        prostorija.vrsta = ProjekatSIMS.Model.UpravnikModel.EnumProstorija.Sala;
                    if (parts[2] == "Kancelarija")
                        prostorija.vrsta = ProjekatSIMS.Model.UpravnikModel.EnumProstorija.Kancelarija;
                    if (parts[2] == "Ordinacija")
                        prostorija.vrsta = ProjekatSIMS.Model.UpravnikModel.EnumProstorija.Ordiracija;
                    if (parts[2] == "Magacin")
                        prostorija.vrsta = ProjekatSIMS.Model.UpravnikModel.EnumProstorija.Magacin;

                    


                    prostorije.Add(prostorija);
                }
                file.Close();

            }
            return prostorije;
        }


    }
}


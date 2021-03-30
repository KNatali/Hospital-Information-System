
using Model.PacijentModel;
using Model.UpravnikModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model.DoktorModel
{
   public class CuvanjePregledaDoktor 
    { 

        private String lokacijaFajla;
        private List<Pregled> pregledi;


        public CuvanjePregledaDoktor(String lokacija)
        {
            lokacijaFajla = lokacija;
        }
      public void Sacuvaj(String pregled,Boolean znak)
      {

            
            using StreamWriter file = new StreamWriter(lokacijaFajla,znak);



            file.WriteLineAsync(pregled);

        }
      
      public List<Pregled> UcitajSvePreglede()
      {
            pregledi = new List<Pregled>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt"))
            {

                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");

                    Pregled pregled = new Pregled();
                    pregled.Id = Convert.ToInt32(parts[0]);
                    pregled.Pocetak = Convert.ToDateTime(parts[3]);
                    pregled.Trajanje = Convert.ToInt32(parts[4]);
                    Prostorija pr = new Prostorija();
                    pr.id = parts[7];
                    pregled.prostorija = pr;

                    //ide da nadje pacijenta sa ucitanim jmbg
                    String line1;
                    using (StreamReader file1 = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pacijent.txt"))
                    {

                        while ((line1 = file1.ReadLine()) != null)
                        {
                            string[] parts1 = line1.Split(",");

                            if (parts1[5] ==parts[1])
                            { 
                                Pacijent p = new Pacijent();
                                p.Ime = parts1[0];
                                p.Prezime = parts1[1];
                                pregled.pacijent = p;
                                break;
                            }
                        }

                        file1.Close();
                    }


                    if (parts[5] == "Standardni")
                        pregled.Tip = TipPregleda.Standardni;
                    if (parts[5] == "Operacija")
                        pregled.Tip = TipPregleda.Operacija;
                    if (parts[6] == "Zavrsen")
                        pregled.StatusPregleda = StatusPregleda.Zavrsen;
                    if (parts[6] == "Zakazan")
                        pregled.StatusPregleda = StatusPregleda.Zakazan;
                    if (parts[6] == "Otkazan")
                        pregled.StatusPregleda = StatusPregleda.Otkazan;


                 pregledi.Add(pregled);
                }

                file.Close();
            }


            return pregledi;
        }
      
      public Pregled UcitajJedanPreglede(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Doktor UcitajDoktora()
      {
         // TODO: implement
         return null;
      }
   
      
   
   }
}
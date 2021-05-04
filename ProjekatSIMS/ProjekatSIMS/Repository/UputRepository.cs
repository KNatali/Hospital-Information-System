using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class UputRepository
    {
        private String putanja = @"..\..\..\Fajlovi\Uput.txt";
        public List<Uput> sviUputi = new List<Uput>();

        public UputRepository()
        {
           
        }

        public void SacuvajUpute(List<Uput> uputi)
        {
            string newJson = JsonConvert.SerializeObject(uputi);
            File.WriteAllText(putanja, newJson);
        }

        public  void SacuvajUput(Uput uput)
        {
            List<Uput> uputi = new List<Uput>();
            if (DobaviUpute() == null)
                uputi = new List<Uput>();
            else
                uputi = DobaviUpute();

            uputi.Add(uput);
            SacuvajUpute(uputi);
        }

        public List<Uput> DobaviUpute(){
            
            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                sviUputi = JsonConvert.DeserializeObject<List<Uput>>(json);
            }
            return sviUputi;
        }

    }
}

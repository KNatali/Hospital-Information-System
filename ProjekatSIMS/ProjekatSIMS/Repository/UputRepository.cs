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

        public void SacuvajUput(List<Uput> uputi)
        {
            string newJson = JsonConvert.SerializeObject(uputi);
            File.WriteAllText(putanja, newJson);
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

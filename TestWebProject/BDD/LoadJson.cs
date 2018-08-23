using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebProject.BDD
{
    public class LoadJson
    {
  
        public void ReadJson()
        {
            using (StreamReader r = new StreamReader("Data.json"))
            {
                string json = r.ReadToEnd();
                List<JsonItems> items = JsonConvert.DeserializeObject<List<JsonItems>>(json);
            }
        }

    }
}

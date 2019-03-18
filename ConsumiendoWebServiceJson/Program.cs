using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsumiendoWebServiceJson
{
    class Program
    {
       // private static readonly HttpClient _service = new HttpClient();
        private static readonly WebClient webClient = new WebClient();
        static void Main(string[] args)
        {
           
           var json = webClient.DownloadString("https://randomuser.me/api/?results=1");
           dynamic listado = JsonConvert.DeserializeObject(json);

            string appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string newpath = appPath.Substring(0,80);


                using (StreamWriter sw = new StreamWriter(Path.Combine(newpath, "users.json")))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    JsonSerializer serializer = new JsonSerializer();
  
                        serializer.Serialize(writer, new
                        {
                           result = JsonConvert.DeserializeObject(json)
                        });                    
                }
            Console.ReadKey();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Thingithon
{
    class Program
    {
        public static string url = "http://thingitude.com/thingithon/mac.html";
        public static int dataCount;
        public static Data[] dataArray;
        static void Main(string[] args)
        {

            WebClient client = new WebClient();
            string webResponse = client.DownloadString(url);


            //Remove first line (due to HTML tag)
            string[] lines = webResponse.Split(Environment.NewLine.ToCharArray()).Skip(1).ToArray();
            string output = string.Join(Environment.NewLine, lines);

            //Stores number of lines
            dataCount = output.Split('\n').Length;

            //Initialize an Array to store Data
            dataArray = new Data[dataCount];

            //Populates Array with mac and time values
            for (int i = 0; i < dataCount; i++)
            {
                dataArray[i] = JsonConvert.DeserializeObject<Data>(lines[i]);
            }




            Console.WriteLine(webResponse);
            Console.WriteLine(dataArray.Length);
            Console.ReadLine();








        }
    }

    
}

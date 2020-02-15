using System;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using model.db;
using model.ViewModels;
using ServiceStack.Text;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest reqGET = WebRequest.Create(@"https://www.telekom.de/autocomplete/v1/streets?zipcode=01067");
            WebResponse resp = reqGET.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string s = sr.ReadToEnd();
            Console.WriteLine(s);

            //var item = JsonExtensions.ArrayObjects(s);
            //item.TrimExcess();
            //item[1]["o1o67"] = s;
            //Console.WriteLine(s);

            var objects = JsonArrayObjects.Parse(s);

            foreach (JsonObject vara in objects)
            {
                foreach (var VARIABLE in vara)
                {
                    var zipCode = VARIABLE.Key;
                    //var city = VARIABLE.Value["City"];
                    //var street = (string) VARIABLE.Value[""];

                    Console.WriteLine(zipCode);
                    //Console.WriteLine(city);
                    //Console.WriteLine(street);
                }
            }

            //AddressViewModel GetData(string opop)
            //{
            //    opop = s;
            //    opop = JsonConverter.
            //    return;
            //}





            //    string url =
            //        "https://www.telekom.de/autocomplete/v1/housenumbers?zipcode=10967&city=Berlin&street=Sch%C3%B6nleinstr.";

            //    using var webClient = new WebClient();
            //    var response = webClient.DownloadString(url);

            //string s = Uri.UnescapeDataString(Regex.Unescape(item));
        }
    }
}

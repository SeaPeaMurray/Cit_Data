using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Web;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;


namespace Testdotnetrestapi
{
    class Program
    {
        private const string URL = "https://api.usaspending.gov/api/v2/bulk_download/list_monthly_files/";
        private const string DATA = @"{""agency"":14,""fiscal_year"": 2015,""type"":""contracts""}";

        static void Main(string[] args)
        {
            Program.CreateObject();
        }


        private static void CreateObject()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }

        }

    }
}

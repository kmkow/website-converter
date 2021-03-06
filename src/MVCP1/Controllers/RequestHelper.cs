using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using Newtonsoft.Json.Linq;


namespace MVCProjekt.Controllers
{
    public static class RequestHelper
    {
        public const string FreeBaseUrl = "https://free.currconv.com/api/v7/";
        public const string PremiumBaseUrl = "https://free.currconv.com/api/v7/";


        public static List<Currency> GetAllCurrencies(string apiKey = null)
        {
            string url;
            if (string.IsNullOrEmpty(apiKey))
                url = FreeBaseUrl + "currencies";
            else
                url = PremiumBaseUrl + "currencies" + "?apiKey=" + apiKey;

            var jsonString = GetResponse(url);

            var data = JObject.Parse(jsonString)["results"].ToArray();
            return data.Select(item => item.First.ToObject<Currency>()).ToList();
        }

       
      

       

        public static double ExchangeRate(CurrencyType from, CurrencyType to, string apiKey = null)
        {
            string url;
            if (string.IsNullOrEmpty(apiKey))
                url = FreeBaseUrl + "convert?q=" + from + "_" + to + "&compact=y";
            else
                url = PremiumBaseUrl + "convert?q=" + from + "_" + to + "&compact=y&apiKey=" + apiKey;

            var jsonString = GetResponse(url);
            return JObject.Parse(jsonString).First.First["val"].ToObject<double>();
        }

        private static string GetResponse(string url)
        {
            string jsonString;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }
    }
}
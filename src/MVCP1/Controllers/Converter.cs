using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjekt.Controllers
{
    public class Converter
    {
        private string ApiKey { get; }
        public Converter()
        {

        }
        public Converter(string apiKey)
        {
            ApiKey = apiKey;
        }

        public double Convert(double amount, CurrencyType from, CurrencyType to)
        {
            return RequestHelper.ExchangeRate(from, to, ApiKey) * amount;
        }

        public async Task<double> ConvertAsync(double amount, CurrencyType from, CurrencyType to)
        {
            return await Task.Run(() => Convert(amount, from, to));
        }



    }
}


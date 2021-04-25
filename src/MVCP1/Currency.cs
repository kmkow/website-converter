using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVCP1
{
    public class Currency
    {
        [JsonProperty("currencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

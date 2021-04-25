using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCP1.Controllers;
using MVCP1;

namespace MVCP1.Models
{
    public class CurrModel
    {
        public double Amount { get; set; }
        public CurrencyType From { get; set; }
        public CurrencyType To { get; set; }

        public double Value { get; set; }

    }
}

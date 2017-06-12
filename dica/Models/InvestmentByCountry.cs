using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dica.Models
{
    public class InvestmentByCountry
    {
        public string Country { get; set; }

        public string Sector { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dica.Models
{
    public class InvestmentByCountryViewModel
    {
        public string TypeOfInvestment { get; set; }

        public string Sector { get; set; }

        public string InvestingCountry { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public List<Country> Countries { get; set; }

        public List<Status> Sectors { get; set; }

        public List<InvestmentByCountry> InvestmentByCountries { get; set; }
    }
}
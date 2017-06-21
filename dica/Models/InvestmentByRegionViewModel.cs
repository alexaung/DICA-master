using System;
using System.Collections.Generic;

namespace dica.Models
{
    public class InvestmentByRegionViewModel
    {
        public string TypeOfInvestment { get; set; }

        public string Sector { get; set; }

        public string InvestingCountry { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public List<string> Regions { get; set; }

        public List<Status> Sectors { get; set; }

        public List<InvestmentByRegion> InvestmentByRegions { get; set; }
    }
}
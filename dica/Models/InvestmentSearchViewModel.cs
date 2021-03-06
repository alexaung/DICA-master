﻿using PagedList;

namespace dica.Models
{
    public class InvestmentSearchViewModel
    {
        public int? Page { get; set; }

        public string TypeOfInvestment { get; set; }

        public string Sector { get; set; }

        public string InvestingCountry { get; set; }
        
        public string CompanyNameinMyanmar { get; set; }

        public string InvestorName { get; set; }

        public  string CreatedBy { get; set; }

        public int? FinancialYearFrom { get; set; }

        public int? FinancialYearTo { get; set; }

        public IPagedList<InvestmentViewModel> SearchResults { get; set; }
    }
}
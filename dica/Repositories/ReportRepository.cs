using dica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace dica.Repositories
{
    public class ReportRepository
    {
        public static List<InvestmentByCountry> GetInvestmentByCountry(InvestmentByCountryViewModel criteria)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = (from investment in db.Investments
                             join sector in db.Statuses on investment.Sector equals sector.Value
                             join investmentPermittedAddress in db.Addresses on investment.InvestmentPermittedAddressId equals investmentPermittedAddress.UID
                             join formofinvestment in db.Statuses on investment.FormofInvestment equals formofinvestment.Value
                             join investingCountry in db.Countries on investment.InvestingCountry equals investingCountry.ISO
                             select new InvestmentViewModel
                             {
                                 UID = investment.UID,
                                 TypeOfInvestmentValue = investment.TypeOfInvestment,
                                 InvestorName = investment.InvestorName,
                                 Citizenship = investment.Citizenship,
                                 OrganizationName = investment.OrganizationName,
                                 IncorporationPlace = investment.IncorporationPlace,
                                 BusinessType = investment.BusinessType,
                                 InvestmentPermittedAddress = investmentPermittedAddress,
                                 AmountofForeignCapital = investment.AmountofForeignCapital,
                                 PeriodforForeignCapitalBroughtin = investment.PeriodforForeignCapitalBroughtin,
                                 PeriodforForeignCapitalBroughtinType = investment.PeriodforForeignCapitalBroughtinType,
                                 TotalAmountofCapital = investment.TotalAmountofCapital,
                                 CapitalCurrency = investment.CapitalCurrency,
                                 ConstructionPeriod = investment.ConstructionPeriod,
                                 ConstructionPeriodType = investment.ConstructionPeriodType,
                                 ValidityofInvestmentPermit = investment.ValidityofInvestmentPermit,
                                 ValidityofInvestmentPermitPeriodType = investment.ValidityofInvestmentPermitPeriodType,
                                 FormofInvestment = formofinvestment.Name,
                                 CompanyNameinMyanmar = investment.CompanyNameinMyanmar,
                                 PermitNo = investment.PermitNo,
                                 PermitDate = investment.PermitDate,
                                 Sector = sector.Name,
                                 InvestingCountry = investingCountry.Name,

                                 SectorValue = sector.Value,
                                 InvestingCountryValue = investingCountry.ISO,
                             });
                if (!string.IsNullOrEmpty(criteria.TypeOfInvestment))
                {
                    query = query.Where(i => i.TypeOfInvestmentValue.Equals(criteria.TypeOfInvestment));
                }
                if (!string.IsNullOrEmpty(criteria.Sector))
                {
                    query = query.Where(i => i.SectorValue.Equals(criteria.Sector));
                }
                if (!string.IsNullOrEmpty(criteria.InvestingCountry))
                {
                    query = query.Where(i => i.InvestingCountryValue.Equals(criteria.InvestingCountry));
                }
                if (criteria.FromDate != null && criteria.FromDate != DateTime.MinValue)
                {
                    query = query.Where(r => DbFunctions.TruncateTime(r.PermitDate) >= DbFunctions.TruncateTime(criteria.FromDate));
                }
                if (criteria.ToDate != null && criteria.ToDate != DateTime.MinValue)
                {
                    query = query.Where(r => DbFunctions.TruncateTime(r.PermitDate) <= DbFunctions.TruncateTime(criteria.ToDate));
                }

                var investmentDto = query.ToList();

                var investmentCountryDto = (from i in investmentDto
                                           group i by new { i.InvestingCountry, i.Sector } into grouping
                                           select new InvestmentByCountry
                                           {
                                               Country = grouping.Key.InvestingCountry,
                                               Sector = grouping.Key.Sector,
                                               Amount = grouping.Sum(i => i.TotalAmountofCapital),
                                               Quantity = grouping.Count()
                                           }).ToList();
                

                return investmentCountryDto;
            }
        }
    }
}
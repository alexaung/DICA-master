using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NPOI.OpenXmlFormats.Spreadsheet;

namespace dica.Models
{
    [Table("Investments")]
    public class Investment
    {
        [Key]
        public Guid UID { get; set; }

        public string TypeOfInvestment { get; set; }

        public string InvestorName { get; set; }

        public string Citizenship { get; set; }

        public Guid InvestorAddressId { get; set; }

        public string OrganizationName { get; set; }

        public Guid OrganizationAddressId { get; set; }

        public string IncorporationPlace { get; set; }

        public string BusinessType { get; set; }

        public Guid InvestmentPermittedAddressId { get; set; }

        public decimal AmountofForeignCapital { get; set; }

        public int PeriodforForeignCapitalBroughtin { get; set; }

        public string PeriodforForeignCapitalBroughtinType { get; set; }

        public decimal TotalAmountofCapital { get; set; }

        public string CapitalCurrency { get; set; }

        public int ConstructionPeriod { get; set; }

        public string ConstructionPeriodType { get; set; }

        public int ValidityofInvestmentPermit { get; set; }

        public string ValidityofInvestmentPermitPeriodType { get; set; }

        public string FormofInvestment { get; set; }
                
        public string CompanyNameinMyanmar { get; set; }

        public int FinancialYearFrom { get; set; }

        public int FinancialYearTo { get; set; }

        public string PermitNo { get; set; }

        public DateTime PermitDate { get; set; }        

        public string Sector { get; set; }

        public string SectorCategory { get; set; }
        
        public string InvestingCountry { get; set; }

        public string Landowner { get; set; }

        public decimal LandArea { get; set; }

        public string LandAreaUnit { get; set; }

        public int LeaseTerm { get; set; }

        public int ExtendedLeaseTerm { get; set; }

        public string AnnualLeaseFee { get; set; }

        public string AnnualLeaseFeeCurrency { get; set; }

        public int TotalNoofLocalEmployee { get; set; }

        public int TotalNoofForeignEmployee { get; set; }

        public int CorporateSocialResponsibility { get; set; }        

        public string EnvironmentandSocialImpactAssessment { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }

        public decimal? LandUsePremium { get; set; }

        public string LandUsePreminumCurrency { get; set; }

        public string Note { get; set; }

    }
}
using dica.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dica.Models
{
    public class InvestmentViewModel
    {
        [Key]
        public Guid UID { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "TypeOfInvestment")]
        public string TypeOfInvestment { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "InvestorName")]
        public string InvestorName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Citizenship")]
        public string Citizenship { get; set; }

        public Address InvestorAddress { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "OrganizationName")]
        public string OrganizationName { get; set; }

        public Address OrganizationAddress { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "IncorporationPlace")]
        public string IncorporationPlace { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "BusinessType")]
        public string BusinessType { get; set; }

        [Required]
        public Address InvestmentPermittedAddress { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AmountofForeignCapital")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.000}")]
        public decimal AmountofForeignCapital { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PeriodforForeignCapitalBroughtin")]
        public int PeriodforForeignCapitalBroughtin { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PeriodforForeignCapitalBroughtinType")]
        public string PeriodforForeignCapitalBroughtinType { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "TotalAmountofCapital")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.000}")]
        public decimal TotalAmountofCapital { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "CapitalCurrency")]
        public string CapitalCurrency { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ConstructionPeriod")]
        public int ConstructionPeriod { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ConstructionPeriodType")]
        public string ConstructionPeriodType { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ValidityofInvestmentPermit")]
        public int ValidityofInvestmentPermit { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ValidityofInvestmentPermitPeriodType")]
        public string ValidityofInvestmentPermitPeriodType { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FormofInvestment")]
        public string FormofInvestment { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "CompanyNameinMyanmar")]
        public string CompanyNameinMyanmar { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FinancialYear")]
        public int FinancialYearFrom { get; set; }

        [Required]
        //[Display(ResourceType = typeof(Resource), Name = "CompanyNameinMyanmar")]
        public int FinancialYearTo { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PermitNo")]
        public string PermitNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(Resource), Name = "PermitDate")]
        public DateTime PermitDate { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Sector")]
        public string Sector { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "SectorCategory")]
        public string SectorCategory { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "InvestingCountry")]
        public string InvestingCountry { get; set; }

        public List<JointVenturePercentage> JointVenturePercentages { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Landowner")]
        public string Landowner { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LandArea")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.000}")]
        public decimal LandArea { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LandAreaUnit")]
        public string LandAreaUnit { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LeaseTerm")]
        public int LeaseTerm { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ExtendedLeaseTerm")]
        public int ExtendedLeaseTerm { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AnnualLeaseFee")]
        public string AnnualLeaseFee { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "TotalNoofLocalEmployee")]
        public int TotalNoofLocalEmployee { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "TotalNoofForeignEmployee")]
        public int TotalNoofForeignEmployee { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "CorporateSocialResponsibility")]
        public int CorporateSocialResponsibility { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "EnvironmentandSocialImpactAssessment")]
        public string[] EnvironmentandSocialImpactAssessment { get; set; }
        
        public string EnvironmentandSocialImpactAssessmentSelected { get; set; }

        public List<Tax> Taxes { get; set; }

        public List<CapitalDetail> CapitalDetails { get; set; }

        public string TypeOfInvestmentValue { get; set; }

        public string SectorValue { get; set; }

        public string InvestingCountryValue { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "CreatedBy")]
        public string CreatedBy { get; set; }
    }
}
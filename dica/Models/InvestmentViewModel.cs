using dica.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dica.Models
{
    public class InvestmentViewModel
    {
        [Key]
        public Guid UID { get; set; }

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
        public decimal AmountofForeignCapital { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PeriodforForeignCapitalBroughtin")]
        public int PeriodforForeignCapitalBroughtin { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "TotalAmountofCapital")]
        public decimal TotalAmountofCapital { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "CapitalCurrency")]
        public string CapitalCurrency { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ConstructionPeriod")]
        public int ConstructionPeriod { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ValidityofInvestmentPermit")]
        public int ValidityofInvestmentPermit { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FormofInvestment")]
        public string FormofInvestment { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "CompanyNameinMyanmar")]
        public string CompanyNameinMyanmar { get; set; }

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

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "InvestingCountry")]
        public string InvestingCountry { get; set; }

        public List<JointVenturePercentage> JointVenturePercentages { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Landowner")]
        public string Landowner { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LandArea")]
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


        public List<CapitalDetail> CapitalDetails { get; set; }
    }
}
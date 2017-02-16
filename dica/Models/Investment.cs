using dica.App_LocalResources;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dica.Models
{
    [Table("Investments")]
    public class Investment
    {
        [Key]
        public Guid UID { get; set; }

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

        public decimal TotalAmountofCapital { get; set; }

        public string CapitalCurrency { get; set; }

        public int ConstructionPeriod { get; set; }

        public int ValidityofInvestmentPermit { get; set; }

        public string FormofInvestment { get; set; }
                
        public string CompanyNameinMyanmar { get; set; }

        public string PermitNo { get; set; }

        public DateTime PermitDate { get; set; }        

        public string Sector { get; set; }
        
        public string InvestingCountry { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        

    }
}
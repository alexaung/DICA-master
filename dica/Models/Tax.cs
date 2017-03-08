using dica.App_LocalResources;
using System;
using System.ComponentModel.DataAnnotations;

namespace dica.Models
{
    public class Tax
    {
        [Key]
        public Guid UID { get; set; }

        public Guid InvestmentId { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "TaxName")]
        public string Name { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Currency")]
        public string Currency { get; set; }
    }
}
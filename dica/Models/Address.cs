using dica.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dica.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public Guid UID { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Line1Address")]
        public string Line1Address { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Line2Address")]
        public string Line2Address { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public string Country { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using dica.App_LocalResources;

namespace dica.Models
{
    public class JointVenturePercentage
    {
        [Key]
        public Guid UID { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Percentage")]
        public int Percentage { get; set; }
    }
}
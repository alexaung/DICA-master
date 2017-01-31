using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dica.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public string ISO { get; set; }

        public string Name { get; set; }

        public string PrintableName { get; set; }

        public string ISO3 { get; set; }

        public int NumCode { get; set; }

    }
}
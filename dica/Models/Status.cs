using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dica.Models
{
    [Table("Statuses")]
    public class Status
    {
        [Key]
        public Guid UID { get; set; }

        public string Group { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
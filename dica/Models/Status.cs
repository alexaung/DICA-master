using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dica.Models
{
    [Table("Statuses")]
    public class Status
    {
        [Key, Column(Order = 0)]
        public Guid UID { get; set; }

        public string Group { get; set; }
        [Key, Column(Order = 1)]
        public string Value { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
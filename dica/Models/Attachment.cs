using System;
using System.ComponentModel.DataAnnotations;

namespace dica.Models
{
    public class Attachment
    {
        [Key]
        public Guid UID { get; set; }

        public Guid InvestmentId { get; set; }

        public string Name { get; set; }

        public int ContentLength { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}
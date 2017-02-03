using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dica.Models
{
    public class AttachmentViewModel
    {
        [Key]
        public Guid UID { get; set; }
        [Required]
        public HttpPostedFileBase File { get; set; }

        public List<Attachment> Attachments { get; set; }
    }
}
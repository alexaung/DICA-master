using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dica.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Investment> Investments { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<JointVenturePercentage> JointVenturePercentages { get; set; }

        public DbSet<CapitalDetail> CapitalDetails { get; set; }

        public DbSet<Tax> Taxes { get; set; }
    }
}
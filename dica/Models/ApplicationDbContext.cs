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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions
                .Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Investment>().Property(p => p.TotalAmountofCapital).HasPrecision(18, 3);
            modelBuilder.Entity<Investment>().Property(p => p.AmountofForeignCapital).HasPrecision(18, 3);
            modelBuilder.Entity<Investment>().Property(p => p.LandArea).HasPrecision(18, 3);

            modelBuilder.Entity<CapitalDetail>().Property(p => p.LocalEquity).HasPrecision(18, 3);
            modelBuilder.Entity<CapitalDetail>().Property(p => p.LocalLone).HasPrecision(18, 3);
            modelBuilder.Entity<CapitalDetail>().Property(p => p.ForeginEquity).HasPrecision(18, 3);
            modelBuilder.Entity<CapitalDetail>().Property(p => p.ForeginLone).HasPrecision(18, 3);
            modelBuilder.Entity<CapitalDetail>().Property(p => p.JvEquity).HasPrecision(18, 3);
            modelBuilder.Entity<CapitalDetail>().Property(p => p.JvLone).HasPrecision(18, 3);

            modelBuilder.Entity<Tax>().Property(p => p.Amount).HasPrecision(18, 3);
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
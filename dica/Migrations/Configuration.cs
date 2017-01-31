namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;   
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var typeofInvestmentMNF = new Status { UID = Guid.Parse("DB7F2BC3-3FBE-47D1-BDA3-2A91921F95BA"), Group = "TypeOfInvestment", Name = "Manufacturing", Value = "MFRG", Order = 1 };
            var typeofInvestmentDIS = new Status { UID = Guid.Parse("0F055019-4F96-4EAD-B3C7-09B4FF1E7714"), Group = "TypeOfInvestment", Name = "Distribution", Value = "DIST", Order = 2 };
            var typeofInvestmentMKT = new Status { UID = Guid.Parse("AD5F39CA-75A2-4CB5-AB1B-3B91188ADF89"), Group = "TypeOfInvestment", Name = "Marketing", Value = "MRKT", Order = 3 };
            context.Statuses.AddOrUpdate(s => s.UID, typeofInvestmentMNF, typeofInvestmentDIS, typeofInvestmentMKT);

            var formofInvestmentJVN = new Status { UID = Guid.Parse("BBF601CB-1590-4D07-BC93-5EE90063DE02"), Group = "FormOfInvestment", Name = "Joint Venture", Value = "JV", Order = 1 };
            var typeofInvestmentMYR = new Status { UID = Guid.Parse("F3CE9988-15BB-417B-B80A-7B73910F87AB"), Group = "FormOfInvestment", Name = "Myanmar", Value = "MYR", Order = 2 };
            var typeofInvestmentFOR = new Status { UID = Guid.Parse("A59628EF-D4C7-4D96-B8F9-F35517574127"), Group = "FormOfInvestment", Name = "Foreign", Value = "FOR", Order = 3 };
            context.Statuses.AddOrUpdate(s => s.UID, formofInvestmentJVN, typeofInvestmentMYR, typeofInvestmentFOR);

            context.SaveChanges();

        }
    }
}

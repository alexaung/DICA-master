namespace dica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        Line1Address = c.String(nullable: false),
                        Line2Address = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        InvestmentId = c.Guid(nullable: false),
                        Name = c.String(),
                        ContentLength = c.Int(nullable: false),
                        ContentType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.CapitalDetails",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        InvestmentId = c.Guid(nullable: false),
                        Description = c.String(),
                        LocalEquity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocalLone = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ForeginEquity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ForeginLone = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ISO = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        PrintableName = c.String(),
                        ISO3 = c.String(),
                        NumCode = c.Int(nullable: false),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.ISO);
            
            CreateTable(
                "dbo.Investments",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        InvestorName = c.String(),
                        Citizenship = c.String(),
                        InvestorAddressId = c.Guid(nullable: false),
                        OrganizationName = c.String(),
                        OrganizationAddressId = c.Guid(nullable: false),
                        IncorporationPlace = c.String(),
                        BusinessType = c.String(),
                        InvestmentPermittedAddressId = c.Guid(nullable: false),
                        AmountofForeignCapital = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PeriodforForeignCapitalBroughtin = c.Int(nullable: false),
                        TotalAmountofCapital = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CapitalCurrency = c.String(),
                        ConstructionPeriod = c.Int(nullable: false),
                        ValidityofInvestmentPermit = c.Int(nullable: false),
                        FormofInvestment = c.String(),
                        CompanyNameinMyanmar = c.String(),
                        PermitNo = c.String(),
                        PermitDate = c.DateTime(nullable: false),
                        Sector = c.String(),
                        InvestingCountry = c.String(),
                        Landowner = c.String(),
                        LandArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LandAreaUnit = c.String(),
                        LeaseTerm = c.Int(nullable: false),
                        ExtendedLeaseTerm = c.Int(nullable: false),
                        AnnualLeaseFee = c.String(),
                        TotalNoofLocalEmployee = c.Int(nullable: false),
                        TotalNoofForeignEmployee = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.JointVenturePercentages",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        InvestmentId = c.Guid(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Percentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        Group = c.String(),
                        Value = c.String(),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Statuses");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.JointVenturePercentages");
            DropTable("dbo.Investments");
            DropTable("dbo.Countries");
            DropTable("dbo.CapitalDetails");
            DropTable("dbo.Attachments");
            DropTable("dbo.Addresses");
        }
    }
}

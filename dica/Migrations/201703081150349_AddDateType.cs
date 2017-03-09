namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "PeriodforForeignCapitalBroughtinType", c => c.String());
            AddColumn("dbo.Investments", "ConstructionPeriodType", c => c.String());
            AddColumn("dbo.Investments", "ValidityofInvestmentPermitPeriodType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "ValidityofInvestmentPermitPeriodType");
            DropColumn("dbo.Investments", "ConstructionPeriodType");
            DropColumn("dbo.Investments", "PeriodforForeignCapitalBroughtinType");
        }
    }
}

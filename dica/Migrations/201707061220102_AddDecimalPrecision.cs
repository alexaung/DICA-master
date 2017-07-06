namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDecimalPrecision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CapitalDetails", "LocalEquity", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.CapitalDetails", "LocalLone", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.CapitalDetails", "ForeginEquity", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.CapitalDetails", "ForeginLone", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.CapitalDetails", "JvEquity", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.CapitalDetails", "JvLone", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Investments", "AmountofForeignCapital", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Investments", "LandArea", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Taxes", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Taxes", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Investments", "LandArea", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Investments", "AmountofForeignCapital", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CapitalDetails", "JvLone", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CapitalDetails", "JvEquity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CapitalDetails", "ForeginLone", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CapitalDetails", "ForeginEquity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CapitalDetails", "LocalLone", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CapitalDetails", "LocalEquity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

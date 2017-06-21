namespace dica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedFinicialYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "FinancialYearFrom", c => c.Int(nullable: false));
            AddColumn("dbo.Investments", "FinancialYearTo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "FinancialYearTo");
            DropColumn("dbo.Investments", "FinancialYearFrom");
        }
    }
}

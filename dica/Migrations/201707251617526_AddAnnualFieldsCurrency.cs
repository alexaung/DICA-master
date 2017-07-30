namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnualFieldsCurrency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "AnnualLeaseFeeCurrency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "AnnualLeaseFeeCurrency");
        }
    }
}

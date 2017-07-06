namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CapitalDetails", "JvEquity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CapitalDetails", "JvLone", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CapitalDetails", "JvLone");
            DropColumn("dbo.CapitalDetails", "JvEquity");
        }
    }
}

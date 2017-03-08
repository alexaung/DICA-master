namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTaxTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Taxes", "Currency", c => c.String(nullable: false));
            DropColumn("dbo.Taxes", "Currenty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Taxes", "Currenty", c => c.String(nullable: false));
            DropColumn("dbo.Taxes", "Currency");
        }
    }
}

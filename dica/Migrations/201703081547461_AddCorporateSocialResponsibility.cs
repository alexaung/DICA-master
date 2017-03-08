namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCorporateSocialResponsibility : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "CorporateSocialResponsibility", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "CorporateSocialResponsibility");
        }
    }
}

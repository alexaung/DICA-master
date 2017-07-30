namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLUPandNoteControl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "LandUsePremium", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Investments", "LandUsePreminumCurrency", c => c.String());
            AddColumn("dbo.Investments", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "Note");
            DropColumn("dbo.Investments", "LandUsePreminumCurrency");
            DropColumn("dbo.Investments", "LandUsePremium");
        }
    }
}

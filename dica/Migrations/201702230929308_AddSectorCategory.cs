namespace dica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSectorCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "SectorCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "SectorCategory");
        }
    }
}

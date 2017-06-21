namespace dica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddTaxes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        InvestmentId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Currenty = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Taxes");
        }
    }
}

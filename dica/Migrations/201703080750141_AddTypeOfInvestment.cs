namespace dica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddTypeOfInvestment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "TypeOfInvestment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "TypeOfInvestment");
        }
    }
}

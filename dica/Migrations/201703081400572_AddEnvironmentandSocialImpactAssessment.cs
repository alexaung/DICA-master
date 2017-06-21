namespace dica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddEnvironmentandSocialImpactAssessment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "EnvironmentandSocialImpactAssessment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investments", "EnvironmentandSocialImpactAssessment");
        }
    }
}

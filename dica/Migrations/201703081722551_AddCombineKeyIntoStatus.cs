namespace dica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCombineKeyIntoStatus : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Statuses");
            AlterColumn("dbo.Statuses", "Value", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Statuses", new[] { "UID", "Value" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Statuses");
            AlterColumn("dbo.Statuses", "Value", c => c.String());
            AddPrimaryKey("dbo.Statuses", "UID");
        }
    }
}

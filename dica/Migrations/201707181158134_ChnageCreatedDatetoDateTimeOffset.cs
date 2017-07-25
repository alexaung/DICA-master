namespace dica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChnageCreatedDatetoDateTimeOffset : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investments", "CreatedOn", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Investments", "ModifiedOn", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Investments", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Investments", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}

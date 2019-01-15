namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ZipCode");
        }
    }
}

namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedthesuspensionkeyforwhenacustomerwantstosuspend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MonthlyCost", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "SuspensionStartDay", c => c.String());
            AddColumn("dbo.Customers", "SuspensionEndDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SuspensionEndDay");
            DropColumn("dbo.Customers", "SuspensionStartDay");
            DropColumn("dbo.Customers", "MonthlyCost");
        }
    }
}

namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcustomer2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "TotalBill", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "MonthlyCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MonthlyCost", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "TotalBill");
        }
    }
}

namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspensionStartDate", c => c.String());
            AddColumn("dbo.Customers", "SuspensionEndDate", c => c.String());
            DropColumn("dbo.Customers", "SuspensionStartDay");
            DropColumn("dbo.Customers", "SuspensionEndDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SuspensionEndDay", c => c.String());
            AddColumn("dbo.Customers", "SuspensionStartDay", c => c.String());
            DropColumn("dbo.Customers", "SuspensionEndDate");
            DropColumn("dbo.Customers", "SuspensionStartDate");
        }
    }
}

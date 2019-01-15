namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTheCustomerModelClassAndAddedSuspensionDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspensionStartDate", c => c.DateTime());
            AddColumn("dbo.Customers", "SuspensionEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SuspensionEndDate");
            DropColumn("dbo.Customers", "SuspensionStartDate");
        }
    }
}

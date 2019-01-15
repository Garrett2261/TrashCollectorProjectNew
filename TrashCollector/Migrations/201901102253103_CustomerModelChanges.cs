namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupBill", c => c.Double());
            AddColumn("dbo.Customers", "PickupStatus", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PickupStatus");
            DropColumn("dbo.Customers", "PickupBill");
        }
    }
}

namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedTheCustomerModelClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "PickupStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickupStatus", c => c.Boolean(nullable: false));
        }
    }
}

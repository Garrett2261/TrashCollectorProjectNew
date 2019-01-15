namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updaedthecustomermodelandaddedanewpropertythatwasreadonlyandsamewiththepickupbill : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PickupStatus", "StatusOfPickup", c => c.Boolean());
            DropColumn("dbo.Customers", "PickupBill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickupBill", c => c.Double());
            AlterColumn("dbo.PickupStatus", "StatusOfPickup", c => c.Boolean(nullable: false));
        }
    }
}

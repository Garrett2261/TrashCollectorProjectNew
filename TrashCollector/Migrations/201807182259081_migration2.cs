namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupDay", c => c.String());
            AddColumn("dbo.Customers", "ExtraPickupDay", c => c.String());
            AddColumn("dbo.Customers", "Bill", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Day", c => c.String());
            DropColumn("dbo.Customers", "Bill");
            DropColumn("dbo.Customers", "ExtraPickupDay");
            DropColumn("dbo.Customers", "PickupDay");
        }
    }
}

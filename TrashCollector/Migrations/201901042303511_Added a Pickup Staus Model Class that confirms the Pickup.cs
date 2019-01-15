namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedaPickupStausModelClassthatconfirmsthePickup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickupStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        StatusOfPickup = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickupStatus", "CustomerId", "dbo.Customers");
            DropIndex("dbo.PickupStatus", new[] { "CustomerId" });
            DropTable("dbo.PickupStatus");
        }
    }
}

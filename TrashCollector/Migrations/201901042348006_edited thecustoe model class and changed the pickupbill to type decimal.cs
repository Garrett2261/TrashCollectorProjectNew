namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedthecustoemodelclassandchangedthepickupbilltotypedecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickupBill", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickupBill", c => c.Single());
        }
    }
}

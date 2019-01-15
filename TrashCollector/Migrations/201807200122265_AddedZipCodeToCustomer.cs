namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedZipCodeToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ZipCode");
        }
    }
}

namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedthebillkeyinCustomermodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Bill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Bill", c => c.Double(nullable: false));
        }
    }
}

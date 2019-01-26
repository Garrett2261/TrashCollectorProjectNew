namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAAddressCityAndStatePropertyToTheCustomerClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Address");
        }
    }
}

namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTheCustomerAndEmployeeModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Date", c => c.DateTime());
            AddColumn("dbo.Customers", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "PickupBill", c => c.Single());
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "ZipCode", c => c.Double(nullable: false));
            AlterColumn("dbo.Employees", "ZipCode", c => c.Double(nullable: false));
            CreateIndex("dbo.Customers", "ApplicationUserId");
            CreateIndex("dbo.Employees", "ApplicationUserId");
            AddForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "ExtraPickupDay");
            DropColumn("dbo.Customers", "TotalBill");
            DropColumn("dbo.Customers", "SuspensionStartDate");
            DropColumn("dbo.Customers", "SuspensionEndDate");
            DropColumn("dbo.Employees", "ConfirmPickup");
            DropColumn("dbo.Employees", "ChargedPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ChargedPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ConfirmPickup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "SuspensionEndDate", c => c.String());
            AddColumn("dbo.Customers", "SuspensionStartDate", c => c.String());
            AddColumn("dbo.Customers", "TotalBill", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ExtraPickupDay", c => c.String());
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "ApplicationUserId");
            DropColumn("dbo.Customers", "PickupBill");
            DropColumn("dbo.Customers", "ApplicationUserId");
            DropColumn("dbo.Customers", "Date");
        }
    }
}

namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        ReturnDate = c.DateTime(storeType: "date"),
                        OriginalCost = c.Int(nullable: false),
                        DiscountAmount = c.Int(nullable: false),
                        LateFeeAmount = c.Int(nullable: false),
                        FinalCost = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20, unicode: false),
                        EmailSent = c.Boolean(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        VoucherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .ForeignKey("dbo.Vouchers", t => t.VoucherId)
                .Index(t => t.VehicleId)
                .Index(t => t.CustomerId)
                .Index(t => t.VoucherId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 50, unicode: false),
                        Model = c.String(nullable: false, maxLength: 50, unicode: false),
                        Year = c.Int(nullable: false),
                        DailyRate = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        DiscountAmount = c.Int(),
                        DiscountPercent = c.Int(),
                        IsUsed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "VoucherId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropIndex("dbo.Rentals", new[] { "VehicleId" });
            DropTable("dbo.Vouchers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Rentals");
            DropTable("dbo.Customers");
        }
    }
}

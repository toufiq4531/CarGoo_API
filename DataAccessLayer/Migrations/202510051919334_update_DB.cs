namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_DB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "OriginalCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Rentals", "DiscountAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Rentals", "LateFeeAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Rentals", "FinalCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Vehicles", "DailyRate", c => c.Double(nullable: false));
            AlterColumn("dbo.Vouchers", "DiscountAmount", c => c.Double());
            AlterColumn("dbo.Vouchers", "DiscountPercent", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vouchers", "DiscountPercent", c => c.Int());
            AlterColumn("dbo.Vouchers", "DiscountAmount", c => c.Int());
            AlterColumn("dbo.Vehicles", "DailyRate", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "FinalCost", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "LateFeeAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "DiscountAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "OriginalCost", c => c.Int(nullable: false));
        }
    }
}

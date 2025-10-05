namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.EF.RentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.EF.RentalContext context)
        {
            //context.Vehicles.AddOrUpdate(
            //    v => v.Id,
            //    new EF.Tables.Vehicle { Brand = "Toyota", Model = "Corolla", Year = 2020, DailyRate = 500, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Honda", Model = "Civic", Year = 2019, DailyRate = 450, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Nissan", Model = "Altima", Year = 2021, DailyRate = 600, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Ford", Model = "Focus", Year = 2018, DailyRate = 400, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "BMW", Model = "X5", Year = 2022, DailyRate = 1200, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Mercedes", Model = "C-Class", Year = 2023, DailyRate = 1300, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Tesla", Model = "Model 3", Year = 2024, DailyRate = 1500, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Kia", Model = "Sportage", Year = 2021, DailyRate = 550, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Hyundai", Model = "Elantra", Year = 2020, DailyRate = 480, Status = "available" },
            //    new EF.Tables.Vehicle { Brand = "Chevrolet", Model = "Malibu", Year = 2019, DailyRate = 520, Status = "available" }
            //);


            //context.Customers.AddOrUpdate(
            //    c => c.Id,
            //    new EF.Tables.Customer { Name = "Toufiq Pranto", Email = "pranto@gmail.com", Phone = "01700000001" },
            //    new EF.Tables.Customer { Name = "Mohammad Tofiqul", Email = "toufiq@gmail.com", Phone = "01700000002" },
            //    new EF.Tables.Customer { Name = "Ali Khan", Email = "ali@example.com", Phone = "01700000003" },
            //    new EF.Tables.Customer { Name = "Emma Brown", Email = "emma@example.com", Phone = "01700000004" },
            //    new EF.Tables.Customer { Name = "David Miller", Email = "david@example.com", Phone = "01700000005" }
            //);


            //context.Vouchers.AddOrUpdate(
            //    v => v.Code,
            //    new EF.Tables.Voucher { Code = "SAVE500", DiscountAmount = 500, DiscountPercent = null, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "PERCENT10", DiscountAmount = null, DiscountPercent = 10, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "WELCOME25", DiscountAmount = 250, DiscountPercent = null, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "LOYAL20", DiscountAmount = null, DiscountPercent = 20, IsUsed = false }
            //);


            //context.SaveChanges();



            //context.Rentals.AddOrUpdate(
            //    r => r.Id,


            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Toyota").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "pranto@gmail.com").Id,
            //    StartDate = new DateTime(2025, 09, 01),
            //    EndDate = new DateTime(2025, 09, 05),
            //    ReturnDate = new DateTime(2025, 09, 05),
            //    OriginalCost = 500 * 4, // 4 days
            //    DiscountAmount = 500, // Voucher applied
            //    LateFeeAmount = 0,
            //    FinalCost = (500 * 4) - 500,
            //    Status = "completed",
            //    VoucherId = context.Vouchers.FirstOrDefault(v => v.Code == "SAVE500").Id,
            //    EmailSent = true
            //},

            //// 2. Completed rental, returned late
            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Honda").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "toufiq@gmail.com").Id,
            //    StartDate = new DateTime(2025, 09, 10),
            //    EndDate = new DateTime(2025, 09, 15),
            //    ReturnDate = new DateTime(2025, 09, 17), // 2 days late
            //    OriginalCost = 450 * 5, // 5 days planned
            //    DiscountAmount = 0,
            //    LateFeeAmount = 900, // 450 * 2 days late
            //    FinalCost = (450 * 5) + 900,
            //    Status = "completed",
            //    VoucherId = null,
            //    EmailSent = true
            //},

            //// 3. Completed rental, used percent voucher
            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "BMW").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "ali@example.com").Id,
            //    StartDate = new DateTime(2025, 08, 20),
            //    EndDate = new DateTime(2025, 08, 27),
            //    ReturnDate = new DateTime(2025, 08, 27),
            //    OriginalCost = 1200 * 7,
            //    DiscountAmount = (1200 * 7) * 0.10, // 10% off
            //    LateFeeAmount = 0,
            //    FinalCost = (1200 * 7) - ((1200 * 7) * 0.10),
            //    Status = "completed",
            //    VoucherId = context.Vouchers.FirstOrDefault(v => v.Code == "PERCENT10").Id,
            //    EmailSent = true
            //}
            //);
            //context.SaveChanges();
        }
    }
}

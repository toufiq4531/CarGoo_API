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
            //    new EF.Tables.Voucher { Code = "LOYAL20", DiscountAmount = null, DiscountPercent = 20, IsUsed = false },

            //    new EF.Tables.Voucher { Code = "SAVE1000", DiscountAmount = 1000, DiscountPercent = null, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "OFF15", DiscountAmount = null, DiscountPercent = 15, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "FREE", DiscountAmount = null, DiscountPercent = 100, IsUsed = true }, // already used
            //    new EF.Tables.Voucher { Code = "VIP30", DiscountAmount = null, DiscountPercent = 30, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "EARLY50", DiscountAmount = 50, DiscountPercent = null, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "WELCOME25", DiscountAmount = 250, DiscountPercent = null, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "LOYAL20", DiscountAmount = null, DiscountPercent = 20, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "PERCENT10", DiscountAmount = null, DiscountPercent = 10, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "SUMMER15", DiscountAmount = null, DiscountPercent = 15, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "RENT75", DiscountAmount = 75, DiscountPercent = null, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "SPRING5", DiscountAmount = null, DiscountPercent = 5, IsUsed = false },
            //    new EF.Tables.Voucher { Code = "FIRSTRIDE", DiscountAmount = 300, DiscountPercent = null, IsUsed = false }

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

            
            // 4️⃣ Completed rental — long-term with 10% discount for >7 days
            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Ford").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "emma@example.com").Id,
            //    StartDate = new DateTime(2025, 07, 01),
            //    EndDate = new DateTime(2025, 07, 10),
            //    ReturnDate = new DateTime(2025, 07, 10),
            //    OriginalCost = 400 * 9,
            //    DiscountAmount = (400 * 9) * 0.10, // 10% long rent discount
            //    LateFeeAmount = 0,
            //    FinalCost = (400 * 9) - ((400 * 9) * 0.10),
            //    Status = "completed",
            //    VoucherId = null,
            //    EmailSent = true
            //},

            //// 5️⃣ Active rental (still ongoing)
            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Tesla").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "david@example.com").Id,
            //    StartDate = new DateTime(2025, 10, 01),
            //    EndDate = new DateTime(2025, 10, 12),
            //    ReturnDate = null,
            //    OriginalCost = 1500 * 11,
            //    DiscountAmount = 0,
            //    LateFeeAmount = 0,
            //    FinalCost = 1500 * 11,
            //    Status = "active",
            //    VoucherId = null,
            //    EmailSent = false
            //},


            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Hyundai").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "pranto@gmail.com").Id,
            //    StartDate = new DateTime(2025, 06, 10),
            //    EndDate = new DateTime(2025, 06, 15),
            //    ReturnDate = new DateTime(2025, 06, 15),
            //    OriginalCost = 480 * 5,
            //    DiscountAmount = 0,
            //    LateFeeAmount = 0,
            //    FinalCost = 480 * 5,
            //    Status = "completed",
            //    VoucherId = null,
            //    EmailSent = true
            //},

            //// 7️⃣ Completed rental — high-end Mercedes, no voucher, no discount
            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Mercedes").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "toufiq@gmail.com").Id,
            //    StartDate = new DateTime(2025, 05, 20),
            //    EndDate = new DateTime(2025, 05, 24),
            //    ReturnDate = new DateTime(2025, 05, 25), // returned late
            //    OriginalCost = 1300 * 4,
            //    DiscountAmount = 0,
            //    LateFeeAmount = 1950, // 1-day late fee
            //    FinalCost = (1300 * 4) + 1950,
            //    Status = "completed",
            //    VoucherId = null,
            //    EmailSent = true
            //},

            //// 8️⃣ Cancelled booking
            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Chevrolet").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "emma@example.com").Id,
            //    StartDate = new DateTime(2025, 09, 02),
            //    EndDate = new DateTime(2025, 09, 06),
            //    ReturnDate = null,
            //    OriginalCost = 520 * 4,
            //    DiscountAmount = 0,
            //    LateFeeAmount = 0,
            //    FinalCost = 0,
            //    Status = "cancelled",
            //    VoucherId = null,
            //    EmailSent = false
            //},


            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Kia").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "ali@example.com").Id,
            //    StartDate = new DateTime(2025, 04, 10),
            //    EndDate = new DateTime(2025, 04, 14),
            //    ReturnDate = new DateTime(2025, 04, 14),
            //    OriginalCost = 550 * 4,
            //    DiscountAmount = 0,
            //    LateFeeAmount = 0,
            //    FinalCost = 550 * 4,
            //    Status = "completed",
            //    VoucherId = null,
            //    EmailSent = true
            //},


            //new EF.Tables.Rental
            //{
            //    VehicleId = context.Vehicles.FirstOrDefault(v => v.Brand == "Nissan").Id,
            //    CustomerId = context.Customers.FirstOrDefault(c => c.Email == "david@example.com").Id,
            //    StartDate = new DateTime(2025, 08, 05),
            //    EndDate = new DateTime(2025, 08, 10),
            //    ReturnDate = new DateTime(2025, 08, 10),
            //    OriginalCost = 600 * 5,
            //    DiscountAmount = 0,
            //    LateFeeAmount = 0,
            //    FinalCost = 600 * 5,
            //    Status = "completed",
            //    VoucherId = null,
            //    EmailSent = true
            //}
            //);

            //context.SaveChanges();

        }
    }
}

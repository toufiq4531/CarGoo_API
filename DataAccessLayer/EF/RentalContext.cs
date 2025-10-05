using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class RentalContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
    }
}

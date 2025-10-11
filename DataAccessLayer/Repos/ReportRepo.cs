using DataAccessLayer.EF;
using DataAccessLayer.EF.Tables;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repos
{
    internal class ReportRepo : IReportRepo
    {
        private readonly RentalContext _context;

        public ReportRepo()
        {
            _context = new RentalContext();
        }

        public List<Rental> GetRentalsByYear(int year)
        {
            return _context.Rentals.Where(r => r.StartDate.Year == year).ToList();
        }

        public List<Rental> GetRentalsByMonth(int year, int month)
        {
            return _context.Rentals.Where(r => r.StartDate.Year == year && r.StartDate.Month == month).ToList();
        }

        public List<Rental> GetAllRentals()
        {
            return _context.Rentals.ToList();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles.ToList();
        }
    }
}

using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class ReportRepo : IReportRepo
    {
        RentalContext RentalContext;
        public ReportRepo()
        {
            RentalContext = new RentalContext();
        }
        public List<RevenueReportDTO> GetMonthlyRevenue(int month)
        {
            var reports = RentalContext.Rentals
                .Where(r => r.StartDate.Month == month)
                .GroupBy(r => r.StartDate.Year)
                .Select(g => new RevenueReportDTO
                {
                    Year = g.Key,
                    Month = month,
                    TotalRevenue = (decimal)g.Sum(r => r.FinalCost),
                    RentalsCount = g.Count(),
                    AveragePerRental = g.Count() > 0 ? (decimal)g.Sum(r => r.FinalCost) / g.Count():0
                })
                .ToList();
            return reports;
        }

        public List<PopularVehicleDTO> GetMostPopularVehicles()
        {
            int top = 3;
            var popularVehicles = RentalContext.Rentals
                .GroupBy(r => r.VehicleId)
                .Select(g => new PopularVehicleDTO
                {
                    VehicleId = g.Key,
                    VehicleModel = g.FirstOrDefault().Vehicle.Model,
                    TotalRentals = g.Count(),
                    TotalDaysRented = g.Sum(r => (r.EndDate - r.StartDate).Days + 1)
                })
                .OrderByDescending(v => v.TotalRentals)
                .ThenByDescending(v => v.TotalDaysRented)
                .Take(top)
                .ToList();
            return popularVehicles;
        }

        public List<RevenueReportDTO> GetYearlyRevenue(int year)
        {
            var reports = RentalContext.Rentals
                .Where(r => r.StartDate.Year == year)
                .GroupBy(r => r.StartDate.Year)
                .Select(g => new RevenueReportDTO
                {
                    Year = year,
                    Month = null,
                    TotalRevenue = (decimal)g.Sum(r => r.FinalCost),
                    RentalsCount = g.Count(),
                    AveragePerRental = g.Count() > 0 ? (decimal)g.Sum(r => r.FinalCost) / g.Count() : 0
                })
                .ToList();
            return reports;
        }
    }
}

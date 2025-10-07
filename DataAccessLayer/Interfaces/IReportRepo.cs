using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class RevenueReportDTO
    {
        public int Year { get; set; }
        public int? Month { get; set; }
        public decimal TotalRevenue { get; set; }
        public int RentalsCount { get; set; }
        public decimal AveragePerRental { get; set; }
    }

    public class PopularVehicleDTO
    {
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; }
        public int TotalRentals { get; set; }
        public int TotalDaysRented { get; set; }
    }
    public interface IReportRepo
    {
        List<RevenueReportDTO> GetMonthlyRevenue(int month);
        List<RevenueReportDTO> GetYearlyRevenue(int year);
        List<PopularVehicleDTO> GetMostPopularVehicles();
    }
}

using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RevenueReportService
    {
        public static List<RevenueReportDTO> GetMonthlyRevenue(int month)
        {
            return DataAccessFactory.ReportData().GetMonthlyRevenue(month);
        }

        public static List<RevenueReportDTO> GetYearlyRevenue(int year)
        {
            return DataAccessFactory.ReportData().GetYearlyRevenue(year);
        }

        public static List<PopularVehicleDTO> GetMostPopularVehicles()
        {
            return DataAccessFactory.ReportData().GetMostPopularVehicles();
        }
    }
}

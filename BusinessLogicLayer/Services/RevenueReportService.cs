using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.EF;
using DataAccessLayer.EF.Tables;
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
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Rental, RentalDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<RevenueReportDTO> GetMonthlyRevenue(int month)
        {
            var rentals = DataAccessFactory.RentalData().Get()
                .Where(r => r.StartDate.Month == month)
                .ToList();

            var rentalDTO = GetMapper().Map<List<RentalDTO>>(rentals);

            var monthlyReports = rentalDTO
                .GroupBy(r => r.StartDate.Month)
                .Select(g => new RevenueReportDTO
                {
                    Year = g.First().StartDate.Year,
                    Month = g.Key,
                    TotalRevenue = (decimal)g.Sum(r => r.FinalCost),
                    RentalsCount = g.Count(),
                    AveragePerRental = g.Count() > 0 ? (decimal)g.Sum(r => r.FinalCost) / g.Count() : 0
                })
                .OrderBy(r => r.Month)
                .ToList();

            return monthlyReports;
        }

        // Get revenue for a specific year (summary)
        public static RevenueReportDTO GetYearlyRevenue(int year)
        {
            var rentals = DataAccessFactory.RentalData().Get()
                .Where(r => r.StartDate.Year == year)
                .ToList();

            var rentalDTO = GetMapper().Map<List<RentalDTO>>(rentals);

            var totalRevenue = (decimal)rentalDTO.Sum(r => r.FinalCost);
            var count = rentalDTO.Count();

            return new RevenueReportDTO
            {
                Year = year,
                Month = null,
                TotalRevenue = totalRevenue,
                RentalsCount = count,
                AveragePerRental = count > 0 ? totalRevenue / count : 0
            };
        }

    }
}

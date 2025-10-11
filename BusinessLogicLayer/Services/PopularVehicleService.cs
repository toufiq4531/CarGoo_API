using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class PopularVehicleService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Rental, RentalDTO>().ReverseMap();
                cfg.CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<PopularVehicleDTO> GetMostPopularVehicles()
        {
            int top = 3;
            var rentals = DataAccessFactory.RentalData().Get();
            var vehicles = DataAccessFactory.VehicleData().Get();

            var rentalDTO = GetMapper().Map<List<RentalDTO>>(rentals);
            var vehicleDTO = GetMapper().Map<List<VehicleDTO>>(vehicles);

            var popularVehicles = rentalDTO
                .GroupBy(r => r.VehicleId)
                .Select(g =>
                {
                    var vehicle = vehicleDTO.FirstOrDefault(v => v.Id == g.Key);
                    return new PopularVehicleDTO
                    {
                        VehicleId = g.Key,
                        VehicleModel = vehicle != null ? $"{vehicle.Brand} {vehicle.Model}" : "Unknown",
                        TotalRentals = g.Count(),
                        TotalDaysRented = g.Sum(r => (r.EndDate - r.StartDate).Days + 1)
                    };
                })
                .OrderByDescending(v => v.TotalRentals)
                .ThenByDescending(v => v.TotalDaysRented)
                .Take(top)
                .ToList();

            return popularVehicles;
        }
    }
}

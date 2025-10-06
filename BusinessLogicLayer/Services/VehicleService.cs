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
    public class VehicleService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<VehicleDTO> Get() 
        {
            var data = DataAccessFactory.VehicleData().Get();
            return GetMapper().Map<List<VehicleDTO>>(data);
        }
        public static VehicleDTO Get(int id) 
        {
            var data = DataAccessFactory.VehicleData().Get(id);
            return GetMapper().Map<VehicleDTO>(data);
        }
        public static bool Create(VehicleDTO vehicle) 
        {
            var data = GetMapper().Map<Vehicle>(vehicle);
            return DataAccessFactory.VehicleData().Create(data);
        }
        public static bool Update(VehicleDTO vehicle) 
        {
            var data = GetMapper().Map<Vehicle>(vehicle);
            return DataAccessFactory.VehicleData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.VehicleData().Delete(id);
        }

    }
}

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
    public class RentalService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Rental, RentalDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<RentalDTO> Get() 
        {
            var data = DataAccessFactory.RentalData().Get();
            return GetMapper().Map<List<RentalDTO>>(data);
        }
        public static RentalDTO Get(int id) 
        {
            var data = DataAccessFactory.RentalData().Get(id);
            return GetMapper().Map<RentalDTO>(data);
        }
        public static bool Create(RentalDTO rental) 
        {
            var data = GetMapper().Map<Rental>(rental);
            return DataAccessFactory.RentalData().Create(data);
        }
        public static bool Update(RentalDTO rental) 
        {
            var data = GetMapper().Map<Rental>(rental);
            return DataAccessFactory.RentalData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RentalData().Delete(id);
        }

    }
}

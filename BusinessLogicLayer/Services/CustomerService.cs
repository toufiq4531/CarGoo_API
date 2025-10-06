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
    public class CustomerService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<CustomerDTO> Get() 
        {
            var data = DataAccessFactory.CustomerData().Get();
            return GetMapper().Map<List<CustomerDTO>>(data);
        }
        public static CustomerDTO Get(int id) 
        {
            var data = DataAccessFactory.CustomerData().Get(id);
            return GetMapper().Map<CustomerDTO>(data);
        }
        public static bool Create(CustomerDTO customer) 
        {
            var data = GetMapper().Map<Customer>(customer);
            return DataAccessFactory.CustomerData().Create(data);
        }
        public static bool Update(CustomerDTO customer) 
        {
            var data = GetMapper().Map<Customer>(customer);
            return DataAccessFactory.CustomerData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CustomerData().Delete(id);
        }
    }
}

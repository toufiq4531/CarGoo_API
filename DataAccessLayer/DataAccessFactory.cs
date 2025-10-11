using DataAccessLayer.Interfaces;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        public static IVehicleRepo VehicleData()
        {
            return new VehicleRepo();
        }
        public static ICustomerRepo CustomerData()
        {
            return new CustomerRepo();
        }
        public static IRentalRepo RentalData()
        {
            return new RentalRepo();
        }
        //public static IReportRepo ReportData()
        //{
        //    return new ReportRepo();
        //}
        public static IVoucherRepo VoucherData()
        {
            return new VoucherRepo();
        }

    }
}

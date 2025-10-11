using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IReportRepo
    {
        List<Rental> GetRentalsByYear(int year);
        List<Rental> GetRentalsByMonth(int year, int month);
        List<Rental> GetAllRentals();
        List<Vehicle> GetAllVehicles();
    }
}

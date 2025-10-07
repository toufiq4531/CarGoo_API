using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class PopularVehicleDTO
    {
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; }
        public int TotalRentals { get; set; }
        public int TotalDaysRented { get; set; }
    }
}

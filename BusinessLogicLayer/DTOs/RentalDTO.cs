using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double OriginalCost { get; set; }
        public double DiscountAmount { get; set; }
        public double LateFeeAmount { get; set; }
        public double FinalCost { get; set; }
        public string Status { get; set; }
        public bool EmailSent { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public int? VoucherId { get; set; }


        //public VehicleDTO VehicleDTO { get; set; }
        //public CustomerDTO CustomerDTO { get; set; }
        //public VoucherDTO VoucherDTO { get; set; }
    }
}

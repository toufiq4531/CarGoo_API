using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class EstimateRentalCostDTO
    {
        public int Days { get; set; }
        public double EstimatedCost { get; set; }
        public double DiscountedAmount { get; set; }
        public double FinalCost { get; set; }
    }
}

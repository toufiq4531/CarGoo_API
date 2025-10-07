using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class VoucherService
    {
        public static double EstimateRentalCostVoucher(int VehicleId, DateTime Start, DateTime End, string VoucherCode)
        {
            var vehicle = DataAccessFactory.VehicleData().Get(VehicleId);

            if (vehicle == null)
                return -1;

            int rentalDays = (End - Start).Days + 1;

            if (rentalDays <= 0)
                return -1;

            double estimatedCost = rentalDays * vehicle.DailyRate;

            if (!string.IsNullOrEmpty(VoucherCode))
            {
                var voucher = DataAccessFactory.VoucherData().Get().FirstOrDefault(v => v.Code == VoucherCode);
                if (voucher != null)
                {
                    if (voucher.DiscountAmount == null)
                    {
                        estimatedCost *= (double)(1 - voucher.DiscountPercent / 100);
                    }
                    else if (voucher.DiscountPercent == null)
                    {
                        estimatedCost -= (double)voucher.DiscountAmount;
                    }
                }
            }
            return estimatedCost;
        }
    }
}

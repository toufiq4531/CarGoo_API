using DataAccessLayer.EF;
using DataAccessLayer.EF.Tables;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class VoucherRepo : IVoucherRepo
    {
        RentalContext RentalContext;
        public VoucherRepo()
        {
            RentalContext = new RentalContext();
        }

        public bool Create(Voucher v)
        {
            RentalContext.Vouchers.Add(v);
            return RentalContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var voucher = RentalContext.Vouchers.Find(id);
            if (voucher == null) return false;
            RentalContext.Vouchers.Remove(voucher);
            return RentalContext.SaveChanges() > 0;
        }

        public List<Voucher> Get()
        {
            return RentalContext.Vouchers.ToList();
        }

        public Voucher Get(int id)
        {
            return RentalContext.Vouchers.Find(id);
        }

        public bool Update(Voucher v)
        {
            var existingVoucher = RentalContext.Vouchers.Find(v.Id);
            if (existingVoucher == null) return false;
            RentalContext.Entry(existingVoucher).CurrentValues.SetValues(v);
            return RentalContext.SaveChanges() > 0;
        }
    }
}

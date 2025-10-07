using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IVoucherRepo
    {
        bool Create(Voucher v);
        List<Voucher> Get();
        Voucher Get(int id);
        bool Update(Voucher v);
        bool Delete(int id);
    }
}

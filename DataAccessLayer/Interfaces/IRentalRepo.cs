using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRentalRepo
    {
        bool Create(Rental r);
        List<Rental> Get();
        Rental Get(int id);
        bool Update(Rental r);
        bool Delete(int id);
    }
}

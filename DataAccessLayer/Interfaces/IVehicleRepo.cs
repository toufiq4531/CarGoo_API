using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    internal interface IVehicleRepo
    {
        bool Create(Vehicle v);
        List<Vehicle> Get();
        Vehicle Get(int id);
        bool Update(Vehicle v);
        bool Delete(int id);
    }
}

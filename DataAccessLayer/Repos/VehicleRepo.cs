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
    internal class VehicleRepo : IVehicleRepo
    {
        RentalContext RentalContext;
        public VehicleRepo() 
        {
            RentalContext = new RentalContext();
        }
        public bool Create(Vehicle v)
        {
            RentalContext.Vehicles.Add(v);
            return RentalContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var vehicle = RentalContext.Vehicles.Find(id);
            if (vehicle == null) return false;
            RentalContext.Vehicles.Remove(vehicle);
            return RentalContext.SaveChanges() > 0;
        }

        public List<Vehicle> Get()
        {
            return RentalContext.Vehicles.ToList();
        }

        public Vehicle Get(int id)
        {
            return RentalContext.Vehicles.Find(id);
        }

        public bool Update(Vehicle v)
        {
            var existingVehicle = RentalContext.Vehicles.Find(v.Id);
            if (existingVehicle == null) return false;
            RentalContext.Entry(existingVehicle).CurrentValues.SetValues(v);
            return RentalContext.SaveChanges() > 0;
        }
    }
}

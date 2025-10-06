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
    internal class RentalRepo : IRentalRepo
    {
        RentalContext RentalContext;
        public RentalRepo()
        {
            RentalContext = new RentalContext();
        }
        public bool Create(Rental r)
        {
            RentalContext.Rentals.Add(r);
            return RentalContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var rental = RentalContext.Rentals.Find(id);
            if (rental == null) return false;
            RentalContext.Rentals.Remove(rental);
            return RentalContext.SaveChanges() > 0;
        }

        public bool Update(Rental r)
        {
            var existingRental = RentalContext.Rentals.Find(r.Id);
            if (existingRental == null) return false;
            RentalContext.Entry(existingRental).CurrentValues.SetValues(r);
            return RentalContext.SaveChanges() > 0;
        }

        List<Rental> IRentalRepo.Get()
        {
            return RentalContext.Rentals.ToList();
        }

        Rental IRentalRepo.Get(int id)
        {
            return RentalContext.Rentals.Find(id);
        }
    }
}

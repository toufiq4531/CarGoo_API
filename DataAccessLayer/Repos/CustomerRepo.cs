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
    internal class CustomerRepo : ICustomerRepo
    {
        RentalContext RentalContext;
        public CustomerRepo()
        {
            RentalContext = new RentalContext();
        }

        public bool Create(Customer c)
        {
            RentalContext.Customers.Add(c);
            return RentalContext.SaveChanges() > 0;
        }

        public List<Customer> Get()
        {
            return RentalContext.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return RentalContext.Customers.Find(id);
        }

        public bool Update(Customer c)
        {
            var existingCustomer = RentalContext.Customers.Find(c.Id);
            if (existingCustomer == null) return false;
            RentalContext.Entry(existingCustomer).CurrentValues.SetValues(c);
            return RentalContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var customer = RentalContext.Customers.Find(id);
            if (customer == null) return false;
            RentalContext.Customers.Remove(customer);
            return RentalContext.SaveChanges() > 0;
        }
    }
}

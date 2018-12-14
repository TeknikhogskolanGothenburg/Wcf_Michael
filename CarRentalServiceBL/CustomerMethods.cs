using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalServiceDL;

namespace CarRentalServiceBL
{
    public class CustomerMethods
    {
        static private CarRentalServicesDBContext _context = new CarRentalServicesDBContext();


        

        public Customer GetCustomer(string option, string term)
        {
            switch (option)
            {
                case "firstname":
                    return _context.Customers.Where(x => x.FirstName == term).FirstOrDefault();
                case "lastname":
                    return _context.Customers.Where(x => x.LastName == term).FirstOrDefault();
                default:
                    return new Customer { };
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Where(x => x.Id == id).FirstOrDefault();
        }



        public bool AddCustomerTodb(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }



        public void RemoveCustomer(string option, string name)
        {
            Customer customer = GetCustomer(option, name);
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("Something went wrong...");
            }

        }


        public void ChangeCustomer(Customer customer)
        {
            var oldCustomer = _context.Customers.Where(x => x.LastName == customer.LastName).FirstOrDefault();
            _context.Customers.Remove(oldCustomer);
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("something went wrong...");
            }
        }

    }
}

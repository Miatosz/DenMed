using System.Collections.Generic;
using System.Linq;
using DenMed.Data;
using DenMed.Models;

namespace DenMed.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private AppDbContext _context;

        public CustomerRepo(AppDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Customer> Customers => 
            _context.Customers;

        public Customer DeleteCustomer(int customerId)
        {
            var deletedCustomer = _context.Customers.FirstOrDefault(c => c.Id == customerId);

            if (deletedCustomer != null)
            {
                _context.Remove(deletedCustomer);
                _context.SaveChanges();
            }
            return deletedCustomer;
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                Customer addedCustomer = _context.Customers
                                            .FirstOrDefault(c => c.Id == customer.Id);
            
                if (addedCustomer != null)
                {
                    addedCustomer.Name = customer.Name;
                    addedCustomer.Pesel = customer.Pesel;
                    addedCustomer.Surname = customer.Surname;
                    addedCustomer.PhoneNumber = customer.PhoneNumber;
                    addedCustomer.Adress = customer.Adress;
                    addedCustomer.AdressId = customer.AdressId;
                }
            }

            _context.SaveChanges();

        }
    }
}
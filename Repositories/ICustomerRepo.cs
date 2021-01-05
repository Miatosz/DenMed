using System.Collections.Generic;
using DenMed.Models;
using DenMed.Models.ViewModels;

namespace DenMed.Repositories
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> Customers {get;}

        void SaveCustomer(Customer customer);

        Customer DeleteCustomer(int customerId);
    }
}
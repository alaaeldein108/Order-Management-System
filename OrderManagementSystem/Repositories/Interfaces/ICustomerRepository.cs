using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<bool> CustomerIsExist(int id);
        Task AddAsync(Customer customer);
        Task<IEnumerable<Order>> GetOrdersAsync(int customerId);


    }
}

using Data.Entities;
using Service.CustomerServices.Dtos;
using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerServices
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerDto customerDto);

        Task<IEnumerable<Order>> GetAllOrders(int customerId);
        Task<IEnumerable<CustomerDto>> GetCustomers();

    }
}

using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context) 
        {
            this.context = context;
        }
        public async Task AddAsync(Customer customer)
        {
           await context.Set<Customer>().AddAsync(customer);
        }

        public async Task<bool> CustomerIsExist(int id)
        {
            return await context.Set<Customer>().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await context.Set<Customer>().ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(int customerId)
        {
            var orders =await context.Set<Order>().Where(x=>x.CustomerId==customerId).Include(x=>x.OrderItems).ToListAsync();
            return orders;
        }

    }
}

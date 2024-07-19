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
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context) 
        {
            this.context = context;
        }
        public async Task AddAsync(Order order)
        {
           await context.Set<Order>().AddAsync(order);
        }

        public async Task<Order> FindAsync(int id)
        {
            var order=await context.Set<Order>().Include(x => x.Customer).Include(x => x.OrderItems)
                             .FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await context.Set<Order>().Include(x=>x.Customer).Include(x=>x.OrderItems).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int customerId)
        {
            var orders = await context.Set<Order>().Where(x => x.CustomerId == customerId).Include(x=>x.Customer).Include(x => x.OrderItems).ToListAsync();
            return orders;
        }

        public void Update(Order order)
        {
            context.Set<Order>().Update(order);
        }
    }
}

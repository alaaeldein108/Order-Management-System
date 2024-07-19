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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Product product)
        {
            await context.Set<Product>().AddAsync(product);
        }

        public async Task<Product> FindAsync(int id)
        {
            var product=await context.Set<Product>().FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var Products=await context.Set<Product>().ToListAsync();
            return Products;
        }

        public void Update(Product product)
        {
             context.Set<Product>().Update(product);
        }
    }
}

using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        void Update(Product product);
        Task<Product> FindAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();

    }
}

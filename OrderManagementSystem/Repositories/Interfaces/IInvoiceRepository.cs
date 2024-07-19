using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task AddInvoice(Invoice invoice);
        Task<Invoice> FindAsync(int id);
        Task<IEnumerable<Invoice>> GetAllAsync();
    }
}

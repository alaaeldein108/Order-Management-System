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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext context;

        public InvoiceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddInvoice(Invoice invoice)
        {
            await context.Set<Invoice>().AddAsync(invoice);
        }

        public async Task<Invoice> FindAsync(int id)
        {
            return await context.Set<Invoice>().FindAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            var invoices=await context.Set<Invoice>().ToListAsync();
            return invoices;
        }
    }
}

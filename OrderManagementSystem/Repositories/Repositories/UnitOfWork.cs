using Data.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public ICustomerRepository CustomerRepository {  get; set; }
        public IInvoiceRepository InvoiceRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            CustomerRepository=new CustomerRepository(context);
            InvoiceRepository=new InvoiceRepository(context);
            OrderRepository=new OrderRepository(context);
            ProductRepository=new ProductRepository(context);
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync(); ;  
        }
    }
}

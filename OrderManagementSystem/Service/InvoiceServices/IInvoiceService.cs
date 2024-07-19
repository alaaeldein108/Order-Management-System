using Data.Entities;
using Service.CustomerServices.Dtos;
using Service.InvoiceServices.Dtos;
using Service.ProductServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InvoiceServices
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId);
        Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();

    }
}

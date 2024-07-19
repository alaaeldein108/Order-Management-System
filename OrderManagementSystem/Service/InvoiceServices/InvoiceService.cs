using AutoMapper;
using Data.Entities;
using Repositories.Interfaces;
using Service.InvoiceServices.Dtos;
using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InvoiceServices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            var invoices = await unitOfWork.InvoiceRepository.GetAllAsync();
            var mappedInvoices = mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            return mappedInvoices;
            
        }

        public async Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId)
        {
            var invoice = await unitOfWork.InvoiceRepository.FindAsync(invoiceId);
            var mappedInvoice = mapper.Map<InvoiceDto>(invoice);
            return mappedInvoice;
        }
    }
}

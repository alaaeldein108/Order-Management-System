using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.InvoiceServices;
using Service.ProductServices;

namespace OrderManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService invoiceService;
        private readonly ILogger<InvoiceController> logger;

        public InvoiceController(IInvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            this.invoiceService = invoiceService;
            this.logger = logger;
        }
        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceByIdAsync(int invoiceId)
        {
            var invoice = await invoiceService.GetInvoiceByIdAsync(invoiceId);
            return Ok(invoice);

        }
        [HttpGet("invoices")]
        public async Task<IActionResult> GetAllInvoicesAsync()
        {
            var invoices = await invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }
    }
}

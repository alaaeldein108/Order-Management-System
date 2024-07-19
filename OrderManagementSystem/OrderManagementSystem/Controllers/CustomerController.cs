using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.CustomerServices;
using Service.CustomerServices.Dtos;
using Service.OrderServices;
using Service.OrderServices.Dtos;

namespace OrderManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Customer")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;
        private readonly ILogger<CustomerController> logger;

        public CustomerController(ICustomerService customerService
            ,IOrderService orderService,ILogger<CustomerController> logger)
        {
            this.customerService = customerService;
            this.orderService = orderService;
            this.logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] CustomerDto customer)
        {
            await customerService.AddCustomerAsync(customer);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(int customerId)
        {
            var orders = await orderService.GetOrdersAsync(customerId);
            return Ok(orders);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await customerService.GetCustomers();
            return Ok(customers);
        }
    }
}

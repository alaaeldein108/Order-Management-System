using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using Repositories.Interfaces;
using Repositories.Repositories;
using Service.CustomerServices;
using Service.CustomerServices.Dtos;
using Service.OrderServices;
using Service.OrderServices.Dtos;
using Service.OrderServices.ViewModel;
using Service.ProductServices;
using Service.ProductServices.Dtos;

namespace OrderManagementSystem.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService orderService,
            IUnitOfWork unitOfWork, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderViewModel model)
        {
            if(await unitOfWork.CustomerRepository.CustomerIsExist(model.OrderDto.CustomerId)==false)
            {
                return BadRequest("Customer Not Exist");
            }
            try
            {
                TinyMapper.Bind<OrderDto, Order>();
                var mappedOrder = TinyMapper.Map<Order>(model.OrderDto);
                mappedOrder.OrderDate = DateTime.Now;
                
                TinyMapper.Bind<List<OrderItemDto>, List<OrderItem>>();
                var orderItems = TinyMapper.Map<List<OrderItem>>(model.OrderItemDto);

                mappedOrder.OrderItems = orderItems;
                foreach (var order in orderItems)
                {
                    if(mappedOrder.Id!=order.OrderId)
                        return BadRequest($"Order {order.OrderId} Not the Same");

                    var product = await unitOfWork.ProductRepository.FindAsync(order.ProductId);
                    order.UnitPrice=product.Price;
                    if (product == null)
                        return BadRequest($"Product with ID {order.ProductId} does not exist.");

                    if (product.Stock < order.Quantity)
                    {
                        return BadRequest($"Insufficient stock for product {product.Name}. Available stock: {product.Stock}.");
                    }

                }
                foreach (var item in orderItems)
                {
                    var product = await unitOfWork.ProductRepository.FindAsync(item.ProductId);
                    product.Stock -= item.Quantity;
                    unitOfWork.ProductRepository.Update(product);
                }
                await orderService.AddNewOrder(mappedOrder);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            var order = await orderService.GetOrdersByIdAsync(orderId);
            return Ok(order);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] OrderStatusDto order)
        {

            var existingOrder = await orderService.GetOrdersByIdAsync(orderId);
            if (existingOrder == null)
            {
                return NotFound();
            }

            await orderService.UpdateOrderAsync(orderId, order);
            return Ok();
        }
    }
}

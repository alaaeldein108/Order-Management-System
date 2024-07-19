using AutoMapper;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        private decimal CalculateTotalAmountOrder(Order input)
        {
            decimal totalAmount = 0;
            decimal discount = 0;

            foreach (var item in input.OrderItems)
            {
                totalAmount += (item.Quantity * item.UnitPrice);
            }
            if (totalAmount > 200)
            {
                discount = 0.10m;
            }
            else if (totalAmount > 100)
            {
                discount = 0.05m;
            }
            decimal totalDiscount = discount* totalAmount;
            return totalAmount- totalDiscount;
        }
        private async Task GenerateInvoice(Order order)
        {
            var invoice = new Invoice
            {
                OrderId = order.Id,
                InvoiceDate = DateTime.Now,
                TotalAmount = order.TotalAmount
            };

            await unitOfWork.InvoiceRepository.AddInvoice(invoice);
            await unitOfWork.CompleteAsync();
        }
        private async Task ValidateOrder(Order order)
        {
            foreach (var item in order.OrderItems)
            {
                var product = await unitOfWork.ProductRepository.FindAsync(item.ProductId);
                if (product.Stock < item.Quantity)
                {
                    throw new Exception($"Insufficient stock for product {product.Name}");
                }
            }
        }
        public OrderService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddNewOrder(Order input)
        {
            var totalAmount = CalculateTotalAmountOrder(input);
            input.TotalAmount = totalAmount;
            ValidateOrder(input);
            await unitOfWork.OrderRepository.AddAsync(input);
            await unitOfWork.CompleteAsync();
            GenerateInvoice(input);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders=await unitOfWork.OrderRepository.GetAllAsync();
            var mappedOrders=mapper.Map<IEnumerable<OrderDto>>(orders);
            return mappedOrders;
        }

        public async Task<OrderDto> GetOrdersByIdAsync(int orderId)
        {   
            var order= await unitOfWork.OrderRepository.FindAsync(orderId);
            var mappedOrded=mapper.Map<OrderDto>(order);
            return mappedOrded;
        }

        public async Task UpdateOrderAsync(int id, OrderStatusDto input)
        {
            var order= await unitOfWork.OrderRepository.FindAsync(id);
            order.OrderPaymentStatus=input.OrderPaymentStatus;
            unitOfWork.OrderRepository.Update(order);
            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int customerId)
        {
            var orders = await unitOfWork.OrderRepository.GetAllOrdersAsync(customerId);
            var mappedOrded = mapper.Map<IEnumerable<OrderDto>>(orders);

            return mappedOrded;
        }
    }
}

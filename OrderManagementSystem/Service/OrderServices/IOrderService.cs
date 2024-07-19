using Data.Entities;
using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderServices
{
    public interface IOrderService
    {
        Task AddNewOrder(Order input);
        Task UpdateOrderAsync(int id,OrderStatusDto input);
        Task<OrderDto> GetOrdersByIdAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDto>> GetOrdersAsync(int customerId);
        
    }
}

using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderServices.ViewModel
{
    public class OrderViewModel
    {
        public OrderDto OrderDto { get; set; }
        public List<OrderItemDto> OrderItemDto { get; set; }

    }
}

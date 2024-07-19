using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderServices.Dtos
{
    public class OrderWithTotalAmountDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderPaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
    }
}

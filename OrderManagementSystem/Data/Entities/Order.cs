using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; } = 0;
        public List<OrderItem> OrderItems { get; set; }
        public string OrderPaymentStatus { get; set; }
        public string PaymentMethod { get; set; }

    }
}

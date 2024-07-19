using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public int Quantity { get; set; }
    }
}

using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerServices.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}

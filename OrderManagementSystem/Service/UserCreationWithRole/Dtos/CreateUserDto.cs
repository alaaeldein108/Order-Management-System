using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserCreationWithRole.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

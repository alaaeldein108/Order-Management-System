using Service.UserCreationWithRole.Dtos;
using Service.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserCreationWithRole
{
    public interface IUserWithRoleService
    {
        Task<CreateUserDto> CreateUser(CreateUserDto input);

    }
}

using Service.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserServices
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterDto input);
        Task<UserDto> Login(LoginDto input);

    }
}

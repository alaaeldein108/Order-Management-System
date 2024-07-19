using Service.RoleServices.Dtos;
using Service.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoleServices
{
    public interface IRoleService
    {
        Task<RoleDto> CreateRoleAsync(RoleDto input);

    }
}

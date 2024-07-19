using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.RoleServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleService(UserManager<ApplicationUser> userManager
            , RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<RoleDto> CreateRoleAsync(RoleDto input)
        {
            ApplicationRole role=new ApplicationRole()
            {
                Name=input.RoleName,
            };
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new RoleDto
                {
                    RoleName = role.Name
                };
            }
            throw new Exception("Role creation failed");

        }
    }
}

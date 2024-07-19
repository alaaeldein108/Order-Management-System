using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.HandleResponse;
using Service.RoleServices;
using Service.UserServices.Dtos;
using Service.UserServices;
using Service.RoleServices.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace OrderManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

    public class RoleController : BaseController
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService) 
        {
            this.roleService = roleService;
        }
        [HttpPost("create")]
        public async Task<ActionResult<RoleDto>> CreateRole(RoleDto input)
        {
            try
            {
                var role = await roleService.CreateRoleAsync(input);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(new CustomException(400, ex.Message));
            }
        }
    }
}

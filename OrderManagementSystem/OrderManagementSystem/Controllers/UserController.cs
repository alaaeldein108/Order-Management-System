using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.HandleResponse;
using Service.UserCreationWithRole;
using Service.UserCreationWithRole.Dtos;
using Service.UserServices;
using Service.UserServices.Dtos;

namespace OrderManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

    public class UserController : BaseController
    {
        private readonly IUserWithRoleService userService;

        public UserController(IUserWithRoleService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserWithRole(CreateUserDto input)
        {
            var user = await userService.CreateUser(input);
            if (user is null)
                return BadRequest(new CustomException(401, "Email already Exist"));
            return Ok(user);
        }
    }
}

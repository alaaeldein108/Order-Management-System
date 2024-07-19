using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.HandleResponse;
using Service.UserServices.Dtos;
using Service.UserServices;

namespace OrderManagementSystem.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto input)
        {
            var user = await userService.Login(input);
            if (user is null)
                return Unauthorized(new CustomException(401));
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto input)
        {
            var user = await userService.Register(input);
            if (user is null)
                return BadRequest(new CustomException(401, "Email already Exist"));
            return Ok(user);
        }
    }
}

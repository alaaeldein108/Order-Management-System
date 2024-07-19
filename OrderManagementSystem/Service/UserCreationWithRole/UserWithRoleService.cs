using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Service.TokenServices;
using Service.UserCreationWithRole.Dtos;
using Service.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserCreationWithRole
{
    public class UserWithRoleService : IUserWithRoleService
    {
        private readonly SignInManager<ApplicationUser> signInManger;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> UserManager;

        public UserWithRoleService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManger, RoleManager<ApplicationRole> roleManager)
        {
            this.UserManager = userManager;
            this.signInManger = signInManger;
            this.roleManager = roleManager;
        }


        public async Task<CreateUserDto> CreateUser(CreateUserDto input)
        {
            var user = await UserManager.FindByEmailAsync(input.Email);
            if (user != null)
                throw new Exception("Email already exists");

            var appUser = new ApplicationUser
            {
                Email = input.Email,
                UserName = input.DisplayName,
            };
            var roleExists = await roleManager.RoleExistsAsync(input.RoleName);
            if (!roleExists)
            {
                throw new Exception($"{input.RoleName} does not exist");
            }
            var result = await UserManager.CreateAsync(appUser, input.Password);
            
            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).FirstOrDefault());

            var roleResult = await UserManager.AddToRoleAsync(appUser, input.RoleName);

            return new CreateUserDto
            {
                Email = input.Email,
                DisplayName = input.DisplayName,
                RoleName=input.RoleName,
            };
        }
    }
}

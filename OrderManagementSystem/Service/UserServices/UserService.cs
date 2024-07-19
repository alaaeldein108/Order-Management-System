﻿using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Service.TokenServices;
using Service.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserServices
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> signInManger;
        private readonly ITokenService tokenService;
        private readonly UserManager<ApplicationUser> UserManager;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManger, ITokenService tokenService)
        {
            this.UserManager = userManager;
            this.signInManger = signInManger;
            this.tokenService = tokenService;
        }

        public async Task<UserDto> Login(LoginDto input)
        {
            var user = await UserManager.FindByEmailAsync(input.Email);
            if (user is null)
                return null;
            var result = await signInManger.CheckPasswordSignInAsync(user, input.Password, false);
            if (!result.Succeeded)
                throw new Exception("Login Failed");
            return new UserDto
            {
                Email = input.Email,
                DisplayName = user.UserName,
                Token =await tokenService.GenerateToken(user),
            };
        }

        public async Task<UserDto> Register(RegisterDto input)
        {
            var user = await UserManager.FindByEmailAsync(input.Email);
            if (user is not null)
                return null;
            var appUser = new ApplicationUser
            {
                Email = input.Email,
                UserName = input.DisplayName,
            };
            var result = await UserManager.CreateAsync(appUser, input.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.Select(x => x.Description).FirstOrDefault());
            return new UserDto
            {
                Email = input.Email,
                DisplayName = input.DisplayName,
                Token =await tokenService.GenerateToken(appUser),
            };
        }
    }
}

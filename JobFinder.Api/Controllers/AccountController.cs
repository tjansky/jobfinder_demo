using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobFinder.Api.Dtos;
using JobFinder.Core.Models;
using JobFinder.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public AccountController(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserWithTokenDto>> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
           using var hmac = new HMACSHA512();

           var user = new User
           {
               Username = registerUserDto.Username,
               Email = registerUserDto.Email,
               PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUserDto.Password)),
               PasswordSalt = hmac.Key
           };

           // add new user to db
           var addedUser = await userService.Register(user);

           // generate token
            string token = tokenService.CreateToken(user);

            var userWithToken = new UserWithTokenDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = 1,
                Token = token
            };

            return userWithToken;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserWithTokenDto>> LoginUser([FromBody] LoginUserDto loginUserDto)
        {
            // get user from db
            var user = await userService.FindByEmail(loginUserDto.Email);

            if (user == null) return Unauthorized("Invalid credentials");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUserDto.Password));
            // check if password is correct
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            // generate token
            string token = tokenService.CreateToken(user);

            var userWithToken = new UserWithTokenDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = 1,
                Token = token
            };

            return userWithToken;
        }
        
    }
}
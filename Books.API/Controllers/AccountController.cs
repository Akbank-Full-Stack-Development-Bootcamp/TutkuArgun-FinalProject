﻿using AutoMapper.Configuration;
using Books.API.Models;
using Books.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;
        private IConfiguration config;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.config = configuration;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var user = userService.GetUser(userLoginModel.Email, userLoginModel.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Hatalı kullanıcı adı ya da şifre " });

            }
            string issuer = "kodluyoruz.com";
            string audience = "kodluyoruz.com";
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Role)

            };
            var key = "Dönülmez akşamın ufkundayız. Vakit çok geç.";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
              issuer: issuer,
              audience: audience,
              claims: claims,
              notBefore: DateTime.Now,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credential

            );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}

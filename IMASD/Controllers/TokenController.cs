using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.API.Controllers
{
    [EnableCors("corsApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;
        private readonly IPasswordService _passwordService;
        public TokenController(IConfiguration configuration, ISecurityService securityService, IPasswordService passwordService)
        {
            _configuration = configuration;
            _securityService = securityService;
            _passwordService = passwordService;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            //If is a valid user
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(
                    new { Token = token, FullName = validation.Item2.UserName, Username = validation.Item2.UserName }
                    );
            }
            return NotFound();
        }
        private async Task<(bool, Security)> IsValidUser(UserLogin login)
        {
            var user = await _securityService.GetLoginByCredentials(login);
            if (user == null)
            {
                return (false, user);
            }
            var isValid = _passwordService.Check(user.Password, login.Password);
            return (isValid, user);
        }
        private string GenerateToken(Security security)
        {
            //Header
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signinCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signinCredentials);
            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,security.UserName),
                new Claim("user" ,security.User),
                new Claim(ClaimTypes.Role,security.Role.ToString()),
            };
            //Payloads
            var paload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );
            var token = new JwtSecurityToken(header, paload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

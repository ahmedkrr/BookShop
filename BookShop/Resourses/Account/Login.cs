using BookShop.Domain;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Resourses.Account
{
    [ApiController]
    [Route("api/Account")]
    public class Login : ControllerBase
    {

       private readonly ApplicationDbContext _dbContext;
       private readonly IConfiguration _config;
    public Login(ApplicationDbContext dbContext, IConfiguration config)
    {
        _dbContext = dbContext;
        _config = config;
    }
        [HttpPost("Login")]
        public async  Task<object> LoginRequest([FromBody] LoginReq request)
        {
            var result = await _dbContext.Set<UserProfile>().FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower() && u.Password == request.password);
            if (User == null)
                return Unauthorized("Password or Email Wrong");

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Id" , result.Id.ToString() ,ClaimValueTypes.Integer),
                new Claim("Name" , result.FirstName ),
                new Claim("Email" , result.Email ),
                new Claim("Role" , result.Role.ToString() ),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials) ;

            var x = new JwtSecurityTokenHandler().WriteToken(token);

            

            return Ok(new LoginResponse
            {
                Message = "Login Success",
                Token = x
            }
                );
        }


}
}

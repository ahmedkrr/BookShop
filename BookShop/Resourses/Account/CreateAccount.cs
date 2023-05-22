using BookShop.Domain;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Resourses
{
    [ApiController]
    [Route("api/Account")]
    public class CreateAccount : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateAccount(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("CreateAccount")]
        public async Task<object> CreateAccountRequest([FromBody] CreateAccountRequest request)
        {
            if(request.Email ==null || request.Password ==null ||request.Name == null)
            {
                return BadRequest("The Fields null ");
            }

            try
            {
                var user = new UserProfile(request.Name, request.MiddleName, request.Email, request.Password);
                if(user != null)
                {
                    _dbContext.Add(user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                {
                    return BadRequest("The email you provided is already in use!");

                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }

            }


            return Ok(new CreateAccountResponse
            {
                 message ="The Account Register Successfully",
                 Email =request.Email,
                 
            }
            );
        }

    }
}

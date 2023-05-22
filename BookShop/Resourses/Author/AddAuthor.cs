using BookShop.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Resourses
{
    [ApiController]
    [Route("api/Author")]
    [Authorize]
    public class AddAuthor : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AddAuthor(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpPost("AddAuthor")]

        public async Task<object> AddAuthorReq([FromBody] AddAuthorRequest model)
        {
            var userRole = User.Claims.First(c => c.Type == "Role")?.Value;
             if(userRole != "admin")
            {
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(model.AuthorName))
            {
                return "Null Value";
            }


            var author = new Author(model.AuthorName);
            await _dbContext.AddAsync(author);

            await _dbContext.SaveChangesAsync();

            return author.Id;

        }

    }


    public class AddAuthorRequest
    {
        public string AuthorName { get;  set; }

    }
}

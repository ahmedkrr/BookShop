using BookShop.Domain;
using BookShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Resourses
{
    [ApiController]
    [Route("api/Book")]
    [Authorize]

    public class AddBook : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AddBook(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("AddBook")]
        
        public async Task<object> AddBookReq([FromBody]AddBookModel model)
        {
            var userRole = User.Claims.First(c => c.Type == "Role")?.Value;
            if (userRole != "Admin")
            {
                return Unauthorized();
            }
            if (string.IsNullOrEmpty(model.Title) || model.AuthorId==0 || model.Rate == 0 ||model.TotalPages==0)
            {
                return "Null Value";
            }

            var Book =  new Book(model.Title, model.Rate, model.TotalPages ,model.PublishDate ,model.AuthorId ,model.BookCount);
            await _dbContext.AddAsync(Book);

            await _dbContext.SaveChangesAsync();

            return Book.Id;

        }
    }
}

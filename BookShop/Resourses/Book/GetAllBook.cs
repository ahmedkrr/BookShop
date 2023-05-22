using BookShop.Domain;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Resourses
{
    [ApiController]
    [Route("api/Author")]
    public class GetAllBook : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllBook(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("GetAllBook")]
        
        public async Task<object> GetAllBookReq()
        {
            var book = await _dbContext.Set<Book>()
                .Include(c => c.Author)
                .Select(s => new GetAllBooksResponse
                {
                    Id = s.Id,
                    Title = s.Title,
                    Rate = s.Rate,
                    TotalPages = s.TotalPages,
                    PublishDate = s.PublishDate,
                    AuthorName = s.Author.AuthorName
                })
                .ToListAsync();
                 



            return book;
        }

    }
}

using BookShop.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Resourses
{
    [ApiController]
    [Route("api/Book")]
    [Authorize]
    public class DeleteBook : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteBook(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<object> DeleteBookRequest([FromRoute] int id)
        {
            var userRole = User.Claims.First(c => c.Type == "Role")?.Value;
            if (userRole != "Admin")
            {
                return Unauthorized();
            }

            var book = await _dbContext.Set<Book>().FirstOrDefaultAsync(c => c.Id == id);

            if (book == null)
                return NoContent();

            _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();

            return Ok("The book deleted successfully ");

        }


    }
}

using BookShop.Domain;
using BookShop.Models;
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
    [Route("Api/Order")]
    [Authorize]
    public class MakeOrder : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public MakeOrder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("MakeOrder")]
        public async Task<object> MakeOrderRequest(MakeOrderReq model)
        {
            List<int> ids = model.Ids;

            if (model.Ids == null)
                return NoContent();

            var userId = User.Claims.First(c => c.Type == "Id")?.Value;

            var orders = new Orders(int.Parse(userId));

            if (orders != null)
            {
                await _dbContext.AddAsync(orders);
                await _dbContext.SaveChangesAsync();


            }
            else
                return BadRequest();

            foreach(var id in ids)
            {
                var book = await _dbContext.Set<Book>().FirstOrDefaultAsync(c => c.Id == id);

            if(book != null) { 
                var order = new Order(orders.Id , id);
                await _dbContext.AddAsync(order);
                 _dbContext.SaveChanges();
                }
            }


            return Ok("The Order ON Request"); ;
        }


    }
}

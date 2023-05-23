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
    public class GetMyAllOrders : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GetMyAllOrders(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("GetMyAllOrder")]
        public async Task<object> GetMyAllOrderRequest()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;

            if (userId == null)
                return BadRequest();

            var Order = await _dbContext.Set<Orders>()
                .Include(ct => ct.Order)
                .Where(c => c.UserProfileId == int.Parse(userId))
                .Select(s => new GetMyAllOrdersUserRequest
                {
                    OrdersId = s.Id,
                    userId = s.UserProfileId,
                    Username = s.UserProfile.FirstName,
                    ResponseOrder = s.ResponseOrder.ToString(),
                    Order = s.Order.Select(s => new GetAllOrder
                    {
                        OrderId = s.Id,
                        BookId = s.BookId,
                        BookName = s.Book.Title,
                    }).ToList()
                }).ToListAsync();

            return Ok(Order);
        }



    }
}

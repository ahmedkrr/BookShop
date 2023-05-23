using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class OrderModel
    {

    }
    public enum ResponseOrder
    {
        undefined = 0,
        OnRequest = 1,
        Approved = 2,
        Decliend = 3
    }
    public class MakeOrderReq
    {
        public List<int> Ids { get; set; }
    }
    public class GetMyAllOrdersUserRequest
    {
        public int OrdersId { get; set; }
        public int userId { get; set; }
        public string Username { get; set; }
        public string ResponseOrder { get; set; }
        public List<GetAllOrder> Order { get; set; }
    }
    public class GetAllOrder
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}

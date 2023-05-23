using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Orders Orders { get; set; }
        public int OrdersId { get; set; }
        public Book Book { get; private set; }
        public int BookId { get; private set; }

        public Order(int ordersId ,int bookId)
        {
            OrdersId = ordersId;
            BookId = bookId;

        }
    }
}

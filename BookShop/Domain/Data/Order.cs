using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain.Data
{
    public class Order
    {
        public int Id { get; set; }

        public Book Book { get; set; }
    }
}

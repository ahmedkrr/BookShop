using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class Orders
    {
        public int Id { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public int UserProfileId { get; set; }

        public ICollection<Order> Order { get; set; }
        public ResponseOrder ResponseOrder { get; private set; }

        public Orders(int userProfileId)
        {
            UserProfileId = userProfileId;

            ResponseOrder = ResponseOrder.OnRequest;
        }

    }
}

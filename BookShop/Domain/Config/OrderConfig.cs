using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> b)
        {
            b.HasOne(c => c.Orders).WithMany(c => c.Order).HasForeignKey(c => c.OrdersId);
            b.HasOne(c => c.Book).WithMany(c => c.Order).HasForeignKey(c => c.BookId);
            

        }
    }
}

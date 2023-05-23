using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class OrdersConfig : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> b)
        {
            b.HasOne(c => c.UserProfile).WithMany(c => c.Orders).HasForeignKey(c => c.UserProfileId);           
        }
    }
}

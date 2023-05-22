using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> b)
        {
            b.Property(p => p.FirstName).HasMaxLength(50).IsRequired(true);
            b.Property(p => p.MiddleName).HasMaxLength(50);
            b.Property(p => p.Email).IsRequired(true);
            b.HasIndex(p => p.Email).IsUnique(true);
        }
    }
}

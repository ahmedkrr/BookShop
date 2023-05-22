using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> b)
        {
            b.Property(p => p.AuthorName).HasMaxLength(100).IsRequired(true);
            b.HasIndex(p => p.AuthorName).IsUnique(true);

        }


    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> b)
        {

            b.Property(p => p.Title).HasMaxLength(100).IsRequired(true);
            b.HasIndex(p => p.Title).IsUnique(true);

            b.Property(p => p.Rate).HasMaxLength(20).IsRequired(true);
            b.Property(p => p.PublishDate).HasMaxLength(50).IsRequired(true);
            b.Property(p => p.TotalPages).HasMaxLength(70).IsRequired(true);
            b.HasOne(p => p.Author).WithMany(p => p.Books).HasForeignKey(p => p.AuthorId);


        }
    }
}

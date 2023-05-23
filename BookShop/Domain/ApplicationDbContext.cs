using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class ApplicationDbContext: DbContext
    {
        public const string ConnectionString = "AutoPart";
        public const string Schema = "SchemaEnd";
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new UserProfileConfig());
            modelBuilder.ApplyConfiguration(new ResetPasswordConfig());
            modelBuilder.ApplyConfiguration(new OrdersConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());

        }
    }
}

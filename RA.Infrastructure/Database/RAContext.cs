using Microsoft.EntityFrameworkCore;
using RA.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Infrastructure.Database
{
    public class RAContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RAContext(DbContextOptions<RAContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RAContext).Assembly);
        }
    }
}

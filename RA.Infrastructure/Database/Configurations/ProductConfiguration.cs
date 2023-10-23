using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RA.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Infrastructure.Database.Configurations
{
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Inv");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => new ProductId(v));

            builder.Property(e => e.Name)
            .HasMaxLength(128).IsRequired();


            builder.OwnsOne(e => e.Price, b =>
            {
                b.Property(e => e.Value)
                .HasColumnName("Price");
            });



        }
    }
}

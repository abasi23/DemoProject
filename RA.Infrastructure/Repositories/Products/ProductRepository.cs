using Microsoft.EntityFrameworkCore;
using RA.Domain.Products;
using RA.Infrastructure.Database;
using RA.Infrastructure.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Infrastructure.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IUnitOfWork uw;
        private readonly RAContext context;

        public ProductRepository(IUnitOfWork uw,RAContext context)
        {
            this.context = context;
            this.uw = uw;
        }

        public async Task<ProductId> AddAsync(Product product)
        {
           await context.AddAsync(product);
           await uw.SaveChangesAsync();
            return product.Id;
        }

        public async Task<ProductId> EditAsync(Product product)
        {
            context.Update(product);
            await uw.SaveChangesAsync();
            return product.Id;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(ProductId id)
        {
            var result = await context.Products.Where(p=>p.Id == id).FirstOrDefaultAsync();
            if (result is null) throw new Exception("product not found.");
            return result;
        }

        public async Task RemoveAsync(ProductId id)
        {
            var result = await context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (result is null) throw new Exception("product not found.");
            context.Remove(result);
            await uw.SaveChangesAsync();
        }
    }
}

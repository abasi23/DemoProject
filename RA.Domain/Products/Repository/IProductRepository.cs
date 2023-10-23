
namespace RA.Domain.Products
{
    public interface IProductRepository
    {
        Task<ProductId> AddAsync(Product product);
        Task<ProductId> EditAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(ProductId id);
        Task RemoveAsync(ProductId id);
    }
}

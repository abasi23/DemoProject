using RA.Application.Products.DTOs;

namespace RA.Application.Products
{
    public interface IProductService
    {
        Task AddAsync(AddProductDto product);
        Task EditAsync(EditProductDto product);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
    }

}
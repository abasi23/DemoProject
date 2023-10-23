using RA.Application.Products.DTOs;
using RA.Domain.Products;

namespace RA.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(AddProductDto product)
        {
            var model = new Product(product.Name, product.Price);
            await _productRepository.AddAsync(model);
        }

        public async Task EditAsync(EditProductDto product)
        {
            var model = await _productRepository.GetByIdAsync(new ProductId(product.Id));
            model.Edit(product.Name, new Price(product.Price));
            await _productRepository.EditAsync(model);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return _productRepository.GetAllAsync().Result.Select(p => new ProductDto { Id = p.Id.Value, Name = p.Name, Price = p.Price.Value }).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var p = await _productRepository.GetByIdAsync(new ProductId(id));
            return new ProductDto { Id = p.Id.Value, Name = p.Name, Price = p.Price.Value };

        }

        public async Task RemoveAsync(Guid id)
        {
           await _productRepository.RemoveAsync(new ProductId(id));
        }
    }
}



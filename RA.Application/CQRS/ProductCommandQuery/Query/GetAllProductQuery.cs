
using MediatR;
using RA.Domain.Products;

namespace RA.Application.CQRS.ProductCommandQuery.Query
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductResponse>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductResponse>>
        {
            private readonly IProductRepository _productRepository;
            public GetAllProductsQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IEnumerable<GetAllProductResponse>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _productRepository.GetAllAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.Select(p=>new GetAllProductResponse
                {
                    Id = p.Id.Value,
                    Name = p.Name,
                    Price = p.Price.Value
                });
            }
        }

    }
        public class GetAllProductResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Decimal Price { get; set; }
        }
}

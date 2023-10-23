using MediatR;
using RA.Domain.Products;

namespace RA.Application.CQRS.ProductCommandQuery.Command
{
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class AddProductHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var model = new Product(request.Name, request.Price);
            var result = await _productRepository.AddAsync(model);
            return new AddProductCommandResponse { ProductId = result.Value};
        }
    }

    public class AddProductCommandResponse
    {
        public Guid ProductId { get; set; }
    }
}

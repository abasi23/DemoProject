using MediatR;
using RA.Domain.Products;

namespace RA.Application.CQRS.ProductCommandQuery.Command
{
    public class RemoveProductCommandRequest : IRequest
    {
        public Guid Id { get; set; }
    }

    public class RemoveProductHandler : IRequestHandler<RemoveProductCommandRequest>
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.RemoveAsync(new ProductId(request.Id));
            return Unit.Value;
        }
    }

}

using MediatR;
using RA.Domain.Products;

namespace RA.Application.CQRS.ProductCommandQuery.Command
{
    public class EditProductCommandRequest : IRequest<EditProductCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class EditProductCommandHandler : IRequestHandler<EditProductCommandRequest, EditProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public EditProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<EditProductCommandResponse> Handle(EditProductCommandRequest request, CancellationToken cancellationToken)
        {
            var model = await _productRepository.GetByIdAsync(new ProductId(request.Id));
            model.Edit(request.Name, new Price(request.Price));
            var result = await _productRepository.EditAsync(model);
            return new EditProductCommandResponse { ProductId = result.Value};
        }
    }
    
    public class EditProductCommandResponse
    {
        public Guid ProductId { get; set; }
    }
}

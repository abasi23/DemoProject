using RA.Domain.Shared;

namespace RA.Domain.Products
{
    public sealed class ProductId : StronglyTypedId<ProductId>
    {
        public ProductId(Guid value):base(value)
        {

        }
    }
}

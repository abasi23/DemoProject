using RA.Domain.Shared;

namespace RA.Domain.Products
{
    public class Product : AggregateRoot<ProductId>
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }

        public void Edit(string name, Price price)
        {
            Name = name;
            Price = price;
        }


        public Product(string name, decimal price)
        {
            Id = new ProductId(Guid.NewGuid());
            Name = name;
            Price = new Price(price);
        }

        private Product() { }
    }
}

using Microsoft.Extensions.DependencyInjection;
using RA.Domain.Products;
using RA.Infrastructure.Repositories.Products;
using RA.Application.Products;
using RA.Infrastructure.Patterns;
using RA.Domain.Patterns;

namespace RA.Config
{
    public class DIConfig
    {
        public static void Init(IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RA.Application.CQRS.ProductCommandQuery.Command;
using RA.Application.CQRS.ProductCommandQuery.Query;
using RA.Application.Products;
using RA.Application.Products.DTOs;

namespace RA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IProductService productService, IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add(AddProductCommandRequest product)
        {
            var result = await mediator.Send(product);
            return Ok(result);
        }

        [HttpPut(nameof(Edit))]
        public async Task<IActionResult> Edit(EditProductCommandRequest product)
        {
            var result = await mediator.Send(product);
            return Ok(result);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(RemoveProductCommandRequest product)
        {
            var result = await mediator.Send(product);
            return Ok(result);
        }
    }
}

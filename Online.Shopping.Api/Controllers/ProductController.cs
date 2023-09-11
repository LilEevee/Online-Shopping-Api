using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Application.Products.Create;
using Online.Shopping.Application.Products.Delete;
using Online.Shopping.Application.Products.Get;
using Online.Shopping.Application.Products.Update;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var getProductQueryById = new GetProductQueryById(new ProductId(id));

            var product = await _mediator.Send(getProductQueryById);

            return Ok(product);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts(string name, int page, int pageSize)
        {
            var getProductQueryById = new GetProductsQuery(name, page, pageSize);

            var products = await _mediator.Send(getProductQueryById);

            return Ok(products);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProductRequest)
        {
            var createProductCommmand = new CreateProductCommand(createProductRequest.Name, createProductRequest.Description,
                createProductRequest.Currency,createProductRequest.Price, createProductRequest.Sku, createProductRequest.Image);

            var createProductResponse = await _mediator.Send(createProductCommmand);

            return Ok(createProductResponse);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest updateProductRequest)
        {
            var updateProductCommand = new UpdateProductCommand(new ProductId(updateProductRequest.ProductId),
                updateProductRequest.Name, updateProductRequest.Description, updateProductRequest.Currency, updateProductRequest.Price, updateProductRequest.Sku, updateProductRequest.Image);
            
            var updateProductResponse = await _mediator.Send(updateProductCommand);

            return Ok(updateProductResponse);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand(new ProductId(id));

            var deleteProductResposne = await _mediator.Send(deleteProductCommand);

            return Ok(deleteProductResposne);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Api.Requests.Product;
using Online.Shopping.Application.Products.Create;
using Online.Shopping.Application.Products.Delete;
using Online.Shopping.Application.Products.Get;
using Online.Shopping.Application.Products.Update;
using Online.Shopping.Domain.Products;

// TODO : FIX ERROR HANDLING

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        public ProductController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var getProductQueryById = new GetProductQueryById(new ProductId(id));

            var product = await _mediator.Send(getProductQueryById);

            return Ok();
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts(string name, int page, int pageSize)
        {
            var getProductQueryById = new GetProductsQuery(name, page, pageSize);

            var products = _mediator.Send(getProductQueryById);

            return Ok();
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProductRequest)
        {
            var createProductCommmand = new CreateProductCommand(new ProductId(createProductRequest.ProductId),
                createProductRequest.Name, createProductRequest.Price, createProductRequest.Sku);

            await _mediator.Send(createProductCommmand);

            return Ok();
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest updateProductRequest)
        {
            var updateProductCommand = new UpdateProductCommand(new ProductId(updateProductRequest.ProductId),
                updateProductRequest.Name, updateProductRequest.Price, updateProductRequest.Sku);
            
                await _mediator.Send(updateProductCommand);

            return Ok();
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteCommand = new DeleteProductCommand(new ProductId(id));

            await _mediator.Send(deleteCommand);

            return Ok();
        }
    }
}
